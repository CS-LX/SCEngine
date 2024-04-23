using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Engine;

namespace SCEngine {
    public class AutoBrowsableTypeDescriptor : CustomTypeDescriptor {
        private readonly Dictionary<string, PropertyDescriptor> _propertyDescriptors;
        private readonly Dictionary<string, PropertyDescriptor> _fieldDescriptors;

        public readonly object _instance;
        public AutoBrowsableTypeDescriptor(ICustomTypeDescriptor parent, Type type, object instance) : base(parent) {
            _propertyDescriptors = new Dictionary<string, PropertyDescriptor>();
            _fieldDescriptors = new Dictionary<string, PropertyDescriptor>();
            _instance = instance;
            // 获取类的所有属性
            var properties = type.GetProperties();

            // 创建属性的 PropertyDescriptor 集合
            foreach (var prop in properties) {
                if (prop.PropertyType == typeof(Vector3)) {
                    _propertyDescriptors[prop.Name] = new PropertyPropertyDescriptor(prop, new Attribute[] { new TypeConverterAttribute(typeof(Vector3TypeConverter)) });
                }
                else if (prop.PropertyType == typeof(Quaternion)) {
                    _propertyDescriptors[prop.Name] = new PropertyPropertyDescriptor(prop, new Attribute[] { new TypeConverterAttribute(typeof(QuaternionTypeConverter)) });
                }
                else {
                    _propertyDescriptors[prop.Name] = new PropertyPropertyDescriptor(prop);
                }
            }

            // 获取类的所有字段
            var fields = type.GetFields();

            // 创建字段的 PropertyDescriptor 集合
            foreach (var field in fields) {
                if (field.FieldType == typeof(Vector3)) {
                    _fieldDescriptors[field.Name] = new FieldPropertyDescriptor(field, new Attribute[] { new TypeConverterAttribute(typeof(Vector3TypeConverter)) });
                }
                else if (field.FieldType == typeof(Quaternion)) {
                    _fieldDescriptors[field.Name] = new FieldPropertyDescriptor(field, new Attribute[] { new TypeConverterAttribute(typeof(QuaternionTypeConverter)) });
                }
                else {
                    _fieldDescriptors[field.Name] = new FieldPropertyDescriptor(field);
                }
            }
        }

        public override PropertyDescriptorCollection GetProperties() {
            var properties = new List<PropertyDescriptor>();

            // 添加属性到属性集合
            foreach (var prop in _propertyDescriptors.Values) {
                properties.Add(new CategoryPropertyDescriptor(prop, "Properties"));
            }

            // 添加字段到属性集合
            foreach (var field in _fieldDescriptors.Values) {
                properties.Add(new CategoryPropertyDescriptor(field, "Fields"));
            }

            return new PropertyDescriptorCollection(properties.ToArray());
        }

        public override PropertyDescriptorCollection GetProperties(Attribute[] attributes) {
            return GetProperties();
        }

        private class PropertyPropertyDescriptor : PropertyDescriptor {
            private readonly PropertyInfo _property;

            public PropertyPropertyDescriptor(PropertyInfo property) : base(property.Name, null) {
                _property = property;
            }

            public override Type PropertyType {
                get {
                    if (_property.PropertyType == typeof(Vector3)) {
                        return typeof(string); // 使用自定义的 TypeConverter 显示为字符串
                    }
                    else if (_property.PropertyType == typeof(Quaternion)) {
                        return typeof(string); // 使用自定义的 TypeConverter 显示为字符串
                    }
                    return _property.PropertyType;
                }
            }

            public override object GetValue(object component) {
                return _property.GetValue(component);
            }

            public override void SetValue(object component, object value) {
                _property.SetValue(component, value);
            }

            // 其他方法保持不变
            public override bool CanResetValue(object component) => false;
            public override void ResetValue(object component) => _property.SetValue(component, Vector3.Zero);
            public override bool ShouldSerializeValue(object component) => false;
            public override bool IsReadOnly => false;
            public override Type ComponentType => _property.DeclaringType;

            // 在构造函数中设置 TypeConverter
            public PropertyPropertyDescriptor(PropertyInfo property, Attribute[] attrs) : base(property.Name, attrs) {
                _property = property;
            }
        }

        private class FieldPropertyDescriptor : PropertyDescriptor {
            private readonly FieldInfo _field;

            public FieldPropertyDescriptor(FieldInfo field) : base(field.Name, null) {
                _field = field;
            }

            public override Type PropertyType {
                get {
                    if (_field.FieldType == typeof(Vector3)) {
                        return typeof(string); // 使用自定义的 TypeConverter 显示为字符串
                    }
                    else if (_field.FieldType == typeof(Quaternion)) {
                        return typeof(string); // 使用自定义的 TypeConverter 显示为字符串
                    }
                    return _field.FieldType;
                }
            }

            public override object GetValue(object component) {
                return _field.GetValue(component);
            }

            public override void SetValue(object component, object value) {
                _field.SetValue(component, value);
            }

            // 其他方法保持不变
            public override bool CanResetValue(object component) => false;
            public override void ResetValue(object component) => _field.SetValue(component, Vector3.Zero);
            public override bool ShouldSerializeValue(object component) => false;
            public override bool IsReadOnly => false;
            public override Type ComponentType => _field.DeclaringType;

            // 在构造函数中设置 TypeConverter
            public FieldPropertyDescriptor(FieldInfo field, Attribute[] attrs) : base(field.Name, attrs) {
                _field = field;
            }
        }

        private class CategoryPropertyDescriptor : PropertyDescriptor {
            private readonly PropertyDescriptor _originalDescriptor;
            private readonly string _category;

            public CategoryPropertyDescriptor(PropertyDescriptor originalDescriptor, string category) : base(originalDescriptor) {
                _originalDescriptor = originalDescriptor;
                _category = category;
            }

            public override string Category => _category;

            // Forward all other PropertyDescriptor methods to the original descriptor
            public override Type ComponentType => _originalDescriptor.ComponentType;
            public override TypeConverter Converter => _originalDescriptor.Converter;
            public override bool IsBrowsable => _originalDescriptor.IsBrowsable;
            public override bool IsReadOnly => _originalDescriptor.IsReadOnly;
            public override Type PropertyType => _originalDescriptor.PropertyType;
            public override bool CanResetValue(object component) => _originalDescriptor.CanResetValue(component);
            public override object GetValue(object component) => _originalDescriptor.GetValue(component);
            public override void ResetValue(object component) => _originalDescriptor.ResetValue(component);
            public override void SetValue(object component, object value) => _originalDescriptor.SetValue(component, value);
            public override bool ShouldSerializeValue(object component) => _originalDescriptor.ShouldSerializeValue(component);
        }
    }

    public class Vector3TypeConverter : ExpandableObjectConverter {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) {
            if (sourceType == typeof(string)) {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) {
            if (value is string strValue) {
                try {
                    string[] parts = strValue.Split(',');
                    if (parts.Length == 3 &&
                        float.TryParse(parts[0], out float x) &&
                        float.TryParse(parts[1], out float y) &&
                        float.TryParse(parts[2], out float z)) {
                        return new Vector3(x, y, z);
                    }
                }
                catch (Exception) {
                    throw new ArgumentException("Invalid Vector3 format. Please use format 'X, Y, Z'.");
                }
            }
            return base.ConvertFrom(context, culture, value);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType) {
            if (destinationType == typeof(string) && value is Vector3 vector3) {
                return $"{vector3.X}, {vector3.Y}, {vector3.Z}";
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes) {
            PropertyDescriptorCollection baseProps = base.GetProperties(context, value, attributes);
            PropertyDescriptor[] props = new PropertyDescriptor[3];
            props[0] = new Vector3PropertyDescriptor("X", typeof(float), context);
            props[1] = new Vector3PropertyDescriptor("Y", typeof(float), context);
            props[2] = new Vector3PropertyDescriptor("Z", typeof(float), context);
            return new PropertyDescriptorCollection(props);
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context) {
            return true;
        }
    }

    public class Vector3PropertyDescriptor : PropertyDescriptor {
        private readonly string _propertyName;
        private readonly Type _propertyType;
        private readonly ITypeDescriptorContext context;

        public Vector3PropertyDescriptor(string propertyName, Type propertyType, ITypeDescriptorContext context)
            : base(propertyName, null) {
            _propertyName = propertyName;
            _propertyType = propertyType;
            this.context = context;
        }

        public override Type ComponentType => typeof(Vector3);

        public override bool IsReadOnly => false;

        public override Type PropertyType => _propertyType;

        public override bool CanResetValue(object component) => false;

        public override object GetValue(object component) {
            Vector3 vector = (Vector3)component;
            switch (_propertyName) {
                case "X":
                    return vector.X;
                case "Y":
                    return vector.Y;
                case "Z":
                    return vector.Z;
                default:
                    throw new ArgumentException($"Invalid property name: {_propertyName}");
            }
        }

        public override void SetValue(object component, object value) {
            Vector3 vector = (Vector3)component;
            float floatValue = Convert.ToSingle(value);
            switch (_propertyName) {
                case "X":
                    vector = new Vector3(floatValue, vector.Y, vector.Z);
                    break;
                case "Y":
                    vector = new Vector3(vector.X, floatValue, vector.Z);
                    break;
                case "Z":
                    vector = new Vector3(vector.X, vector.Y, floatValue);
                    break;
                default:
                    throw new ArgumentException($"Invalid property name: {_propertyName}");
            }

            // 获取对应的属性描述符
            var propertyDescriptor = context.PropertyDescriptor;
            var propertyInstance = context.Instance;
            if (propertyDescriptor != null && propertyInstance is AutoBrowsableTypeDescriptor descriptor) {
                // 将新的 Vector3 值设置到属性描述符所属的类实例中
                propertyDescriptor.SetValue(descriptor._instance, vector);
            }
        }

        public override void ResetValue(object component) {
            // Not implemented
        }

        public override bool ShouldSerializeValue(object component) {
            // Not implemented
            return false;
        }
    }

    public class QuaternionTypeConverter : ExpandableObjectConverter {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) {
            if (sourceType == typeof(string)) {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) {
            if (value is string strValue) {
                try {
                    string[] parts = strValue.Split(',');
                    if (parts.Length == 4 &&
                        float.TryParse(parts[0], out float x) &&
                        float.TryParse(parts[1], out float y) &&
                        float.TryParse(parts[2], out float z) &&
                        float.TryParse(parts[3], out float w)
                        ) {
                        return new Quaternion(x, y, z, w);
                    }
                }
                catch (Exception) {
                    throw new ArgumentException("Invalid Quaternion format. Please use format 'X, Y, Z'.");
                }
            }
            return base.ConvertFrom(context, culture, value);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType) {
            if (destinationType == typeof(string) && value is Quaternion quaternion) {
                return $"{quaternion.X}, {quaternion.Y}, {quaternion.Z}, {quaternion.W}";
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes) {
            PropertyDescriptorCollection baseProps = base.GetProperties(context, value, attributes);
            PropertyDescriptor[] props = new PropertyDescriptor[4];
            props[0] = new QuaternionPropertyDescriptor("X", typeof(float), context);
            props[1] = new QuaternionPropertyDescriptor("Y", typeof(float), context);
            props[2] = new QuaternionPropertyDescriptor("Z", typeof(float), context);
            props[3] = new QuaternionPropertyDescriptor("W", typeof(float), context);
            return new PropertyDescriptorCollection(props);
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context) {
            return true;
        }
    }

    public class QuaternionPropertyDescriptor : PropertyDescriptor {
        private readonly string _propertyName;
        private readonly Type _propertyType;
        private readonly ITypeDescriptorContext context;

        public QuaternionPropertyDescriptor(string propertyName, Type propertyType, ITypeDescriptorContext context)
            : base(propertyName, null) {
            _propertyName = propertyName;
            _propertyType = propertyType;
            this.context = context;
        }

        public override Type ComponentType => typeof(Quaternion);

        public override bool IsReadOnly => false;

        public override Type PropertyType => _propertyType;

        public override bool CanResetValue(object component) => false;

        public override object GetValue(object component) {
            Quaternion quaternion = (Quaternion)component;
            switch (_propertyName) {
                case "X":
                    return quaternion.X;
                case "Y":
                    return quaternion.Y;
                case "Z":
                    return quaternion.Z;
                case "W":
                    return quaternion.W;
                default:
                    throw new ArgumentException($"Invalid property name: {_propertyName}");
            }
        }

        public override void SetValue(object component, object value) {
            Quaternion quaternion = (Quaternion)component;
            float floatValue = Convert.ToSingle(value);
            switch (_propertyName) {
                case "X":
                    quaternion = new Quaternion(floatValue, quaternion.Y, quaternion.Z, quaternion.W);
                    break;
                case "Y":
                    quaternion = new Quaternion(quaternion.X, floatValue, quaternion.Z, quaternion.W);
                    break;
                case "Z":
                    quaternion = new Quaternion(quaternion.X, quaternion.Y, floatValue, quaternion.W);
                    break;
                case "W":
                    quaternion = new Quaternion(quaternion.X, quaternion.Y, quaternion.Z, floatValue); ;
                    break;
                default:
                    throw new ArgumentException($"Invalid property name: {_propertyName}");
            }

            // 获取对应的属性描述符
            var propertyDescriptor = context.PropertyDescriptor;
            var propertyInstance = context.Instance;
            if (propertyDescriptor != null && propertyInstance is AutoBrowsableTypeDescriptor descriptor) {
                // 将新的 Vector3 值设置到属性描述符所属的类实例中
                propertyDescriptor.SetValue(descriptor._instance, quaternion);
            }
        }

        public override void ResetValue(object component) {
            // Not implemented
        }

        public override bool ShouldSerializeValue(object component) {
            // Not implemented
            return false;
        }
    }
}
