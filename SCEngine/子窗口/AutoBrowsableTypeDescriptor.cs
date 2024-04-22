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

        public AutoBrowsableTypeDescriptor(ICustomTypeDescriptor parent, Type type) : base(parent) {
            _propertyDescriptors = new Dictionary<string, PropertyDescriptor>();
            _fieldDescriptors = new Dictionary<string, PropertyDescriptor>();

            // 获取类的所有属性
            var properties = type.GetProperties();

            // 创建属性的 PropertyDescriptor 集合
            foreach (var prop in properties) {
                if (prop.PropertyType == typeof(Vector3)) {
                    _propertyDescriptors[prop.Name] = new PropertyPropertyDescriptor(prop, new Attribute[] { new TypeConverterAttribute(typeof(Vector3TypeConverter)) });
                }
                else {
                    _propertyDescriptors[prop.Name] = new PropertyPropertyDescriptor(prop);
                }
            }

            // 获取类的所有字段
            var fields = type.GetFields();

            // 创建字段的 PropertyDescriptor 集合
            foreach (var field in fields) {
                _fieldDescriptors[field.Name] = new FieldPropertyDescriptor(field);
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
                    return _property.PropertyType;
                }
            }

            public override object GetValue(object component) {
                if (_property.PropertyType == typeof(Vector3)) {
                    var vector3 = (Vector3)_property.GetValue(component);
                    return $"{vector3.X}, {vector3.Y}, {vector3.Z}";
                }
                return _property.GetValue(component);
            }

            public override void SetValue(object component, object value) {
                if (_property.PropertyType == typeof(Vector3)) {
                    if (value is string str) {
                        var parts = str.Split(',');
                        if (parts.Length == 3 && float.TryParse(parts[0], out float x) && float.TryParse(parts[1], out float y) && float.TryParse(parts[2], out float z)) {
                            _property.SetValue(component, new Vector3(x, y, z));
                            return;
                        }
                    }
                    throw new ArgumentException("Invalid Vector3 format. Use 'X, Y, Z' format.");
                }
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
                    return _field.FieldType;
                }
            }

            public override object GetValue(object component) {
                if (_field.FieldType == typeof(Vector3)) {
                    var vector3 = (Vector3)_field.GetValue(component);
                    return $"{vector3.X}, {vector3.Y}, {vector3.Z}";
                }
                return _field.GetValue(component);
            }

            public override void SetValue(object component, object value) {
                if (_field.FieldType == typeof(Vector3)) {
                    if (value is string str) {
                        var parts = str.Split(',');
                        if (parts.Length == 3 && float.TryParse(parts[0], out float x) && float.TryParse(parts[1], out float y) && float.TryParse(parts[2], out float z)) {
                            _field.SetValue(component, new Vector3(x, y, z));
                            return;
                        }
                    }
                    throw new ArgumentException("Invalid Vector3 format. Use 'X, Y, Z' format.");
                }
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

    public class Vector3TypeConverter : TypeConverter {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) {
            return destinationType == typeof(string);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType) {
            if (value is Vector3 vector3 && destinationType == typeof(string)) {
                return $"{vector3.X}, {vector3.Y}, {vector3.Z}";
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
