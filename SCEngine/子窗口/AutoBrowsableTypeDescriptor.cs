using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;
using Engine;
using Color = Engine.Color;

namespace SCEngine {
    public class AutoBrowsableTypeDescriptor : CustomTypeDescriptor {
        private readonly Dictionary<string, PropertyDescriptor> _propertyDescriptors;
        private readonly Dictionary<string, PropertyDescriptor> _fieldDescriptors;

        private readonly Dictionary<string, string>? _descriptions;

        public readonly object _instance;
        public AutoBrowsableTypeDescriptor(ICustomTypeDescriptor parent, Type type, object instance, Dictionary<string, string>? descriptions) : base(parent) {
            _propertyDescriptors = new Dictionary<string, PropertyDescriptor>();
            _fieldDescriptors = new Dictionary<string, PropertyDescriptor>();
            _instance = instance;
            _descriptions = descriptions;
            // 获取类的所有属性
            var properties = type.GetProperties();

            // 创建属性的 PropertyDescriptor 集合
            foreach (var prop in properties) {
                //获取注释
                string propDesc = string.Empty;
                if (_descriptions != null) {
                    _descriptions.TryGetValue(prop.Name, out propDesc);
                }
                propDesc += $"\r\n类型: {prop.PropertyType}";

                //添加属性
                List<Attribute> attrs = [new DescriptionAttribute(propDesc)];
                switch (prop.PropertyType) {
                    case Type a when a == typeof(Vector3):
                        attrs.Add(new TypeConverterAttribute(typeof(Vector3TypeConverter)));
                        break;
                    case Type a when a == typeof(Quaternion):
                        attrs.Add(new TypeConverterAttribute(typeof(QuaternionTypeConverter)));
                        break;
                    case Type a when a == typeof(Vector2):
                        attrs.Add(new TypeConverterAttribute(typeof(Vector2TypeConverter)));
                        break;
                    case Type a when a == typeof(Color):
                        attrs.Add(new EditorAttribute(typeof(ColorExEditor), typeof(UITypeEditor)));
                        break;
                    case Type a when a == typeof(Matrix):
                        attrs.Add(new EditorAttribute(typeof(MatrixEditor), typeof(UITypeEditor)));
                        break;
                    case Type a when a == typeof(TemplatesDatabase.ValuesDictionary):
                        attrs.Add(new TypeConverterAttribute(typeof(ValuesDictionaryConverter)));
                        break;
                    case Type a when a.IsSubclassOf(typeof(GameEntitySystem.Component)) || a.IsSubclassOf(typeof(GameEntitySystem.Subsystem)):
                        attrs.Add(new EditorAttribute(typeof(ECSEditor), typeof(UITypeEditor)));
                        break;
                }

                _propertyDescriptors[prop.Name] = new PropertyPropertyDescriptor(prop, attrs.ToArray());
            }

            // 获取类的所有字段
            var fields = type.GetFields();

            // 创建字段的 PropertyDescriptor 集合
            foreach (var field in fields) {
                //获取注释
                string fieldDesc = string.Empty;
                if (_descriptions != null) {
                    _descriptions.TryGetValue(field.Name, out fieldDesc);
                }
                fieldDesc += $"\r\n类型: {field.FieldType}";

                //添加属性
                List<Attribute> attrs = [new DescriptionAttribute(fieldDesc)];
                switch (field.FieldType) {
                    case Type a when a == typeof(Vector3):
                        attrs.Add(new TypeConverterAttribute(typeof(Vector3TypeConverter)));
                        break;
                    case Type a when a == typeof(Quaternion):
                        attrs.Add(new TypeConverterAttribute(typeof(QuaternionTypeConverter)));
                        break;
                    case Type a when a == typeof(Vector2):
                        attrs.Add(new TypeConverterAttribute(typeof(Vector2TypeConverter)));
                        break;
                    case Type a when a == typeof(Color):
                        attrs.Add(new EditorAttribute(typeof(ColorExEditor), typeof(UITypeEditor)));
                        break;
                    case Type a when a == typeof(Matrix):
                        attrs.Add(new EditorAttribute(typeof(MatrixEditor), typeof(UITypeEditor)));
                        break;
                    case Type a when a == typeof(TemplatesDatabase.ValuesDictionary):
                        attrs.Add(new TypeConverterAttribute(typeof(ValuesDictionaryConverter)));
                        break;
                    case Type a when a.IsSubclassOf(typeof(GameEntitySystem.Component)) || a.IsSubclassOf(typeof(GameEntitySystem.Subsystem)):
                        attrs.Add(new EditorAttribute(typeof(ECSEditor), typeof(UITypeEditor)));
                        break;
                }

                _fieldDescriptors[field.Name] = new FieldPropertyDescriptor(field, attrs.ToArray());
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

        public class PropertyPropertyDescriptor : PropertyDescriptor {
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
                    else if (_property.PropertyType == typeof(Vector2)) {
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
            public override void ResetValue(object component) { }
            public override bool ShouldSerializeValue(object component) => false;
            public override bool IsReadOnly => false;
            public override Type ComponentType => _property.DeclaringType;

            // 在构造函数中设置 TypeConverter
            public PropertyPropertyDescriptor(PropertyInfo property, Attribute[] attrs) : base(property.Name, attrs) {
                _property = property;
            }
        }

        public class FieldPropertyDescriptor : PropertyDescriptor {
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
                    else if (_field.FieldType == typeof(Vector2)) {
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
            public override void ResetValue(object component) { }
            public override bool ShouldSerializeValue(object component) => false;
            public override bool IsReadOnly => false;
            public override Type ComponentType => _field.DeclaringType;

            // 在构造函数中设置 TypeConverter
            public FieldPropertyDescriptor(FieldInfo field, Attribute[] attrs) : base(field.Name, attrs) {
                _field = field;
            }
        }

        public class CategoryPropertyDescriptor : PropertyDescriptor {
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

    public class Vector2TypeConverter : ExpandableObjectConverter {
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
                    if (parts.Length == 2 &&
                        float.TryParse(parts[0], out float x) &&
                        float.TryParse(parts[1], out float y)) {
                        return new Vector2(x, y);
                    }
                }
                catch (Exception) {
                    throw new ArgumentException("Invalid Vector3 format. Please use format 'X, Y, Z'.");
                }
            }
            return base.ConvertFrom(context, culture, value);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType) {
            if (destinationType == typeof(string) && value is Vector2 vector2) {
                return $"{vector2.X}, {vector2.Y}";
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes) {
            PropertyDescriptorCollection baseProps = base.GetProperties(context, value, attributes);
            PropertyDescriptor[] props = new PropertyDescriptor[2];
            props[0] = new Vector2PropertyDescriptor("X", typeof(float), context);
            props[1] = new Vector2PropertyDescriptor("Y", typeof(float), context);
            return new PropertyDescriptorCollection(props);
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context) {
            return true;
        }
    }

    public class Vector2PropertyDescriptor : PropertyDescriptor {
        private readonly string _propertyName;
        private readonly Type _propertyType;
        private readonly ITypeDescriptorContext context;

        public Vector2PropertyDescriptor(string propertyName, Type propertyType, ITypeDescriptorContext context)
            : base(propertyName, null) {
            _propertyName = propertyName;
            _propertyType = propertyType;
            this.context = context;
        }

        public override Type ComponentType => typeof(Vector2);

        public override bool IsReadOnly => false;

        public override Type PropertyType => _propertyType;

        public override bool CanResetValue(object component) => false;

        public override object GetValue(object component) {
            Vector2 vector = (Vector2)component;
            switch (_propertyName) {
                case "X":
                    return vector.X;
                case "Y":
                    return vector.Y;
                default:
                    throw new ArgumentException($"Invalid property name: {_propertyName}");
            }
        }

        public override void SetValue(object component, object value) {
            Vector2 vector = (Vector2)component;
            float floatValue = Convert.ToSingle(value);
            switch (_propertyName) {
                case "X":
                    vector = new Vector2(floatValue, vector.Y);
                    break;
                case "Y":
                    vector = new Vector2(vector.X, floatValue);
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

    public class ColorExEditor : UITypeEditor {
        private ColorExEditorDialog dialog;

        public ColorExEditor() {
            dialog = new ColorExEditorDialog();
            dialog.TopLevel = false;
        }


        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) {
            return UITypeEditorEditStyle.DropDown;
        }

        /// <summary>
        /// 编辑值
        /// </summary>
        /// <param name="context">可用于获取附加上下文信息的 ITypeDescriptorContext。</param>
        /// <param name="provider">一个 IServiceProvider ，此编辑器可用它来获取服务</param>
        /// <param name="value">要编辑的对象。</param>
        /// <returns>对象的新值。 如果尚未更改对象的值，则它返回的对象应与传递给它的对象相同。</returns>
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value) {
            if (context != null && context.Instance != null && provider != null) {
                IWindowsFormsEditorService service = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
                if (service != null) {
                    Color color = (Color)value;
                    dialog.DataSource = color;
                    // 在提供此服务的属性网格的值字段下方的下拉区域中显示指定控件。
                    service.DropDownControl(dialog);
                    return dialog.Value;
                }
            }
            return null;
        }
    }

    public class ColorExEditorDialog : ColorExDialog {
        public ColorExEditorDialog() {
            InitializeComponent();
        }

        public ColorExEditorDialog(IContainer container) {
            container.Add(this);

            InitializeComponent();
        }

        #region 绑定数据源

        public new object DataSource {
            set {
                InitalColor = (Color)value;
            }
        }

        public Color Value => SelectedColor;

        #endregion
    }

    public class MatrixEditor : UITypeEditor {
        private MatrixEditorDialog dialog;

        public MatrixEditor() {
            dialog = new MatrixEditorDialog();
            dialog.TopLevel = false;
        }


        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) {
            return UITypeEditorEditStyle.DropDown;
        }

        /// <summary>
        /// 编辑值
        /// </summary>
        /// <param name="context">可用于获取附加上下文信息的 ITypeDescriptorContext。</param>
        /// <param name="provider">一个 IServiceProvider ，此编辑器可用它来获取服务</param>
        /// <param name="value">要编辑的对象。</param>
        /// <returns>对象的新值。 如果尚未更改对象的值，则它返回的对象应与传递给它的对象相同。</returns>
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value) {
            if (context != null && context.Instance != null && provider != null) {
                IWindowsFormsEditorService service = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
                if (service != null) {
                    Matrix matrix = (Matrix)value;
                    dialog.DataSource = matrix;
                    // 在提供此服务的属性网格的值字段下方的下拉区域中显示指定控件。
                    service.DropDownControl(dialog);
                    return dialog.Value;
                }
            }
            return null;
        }
    }

    public class MatrixEditorDialog : MatrixDialog {
        public MatrixEditorDialog() {
            InitializeComponent();
        }

        public MatrixEditorDialog(IContainer container) {
            container.Add(this);

            InitializeComponent();
        }

        #region 绑定数据源
        public Matrix DataSource {
            set {
                InitalMatrix = (Matrix)value;
                SetValue();
            }
        }

        public Matrix Value => GetValue();
        #endregion
    }

    public class ValuesDictionaryConverter : ExpandableObjectConverter {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) {
            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) {
            return base.ConvertFrom(context, culture, value);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType) {
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes) {
            if (value is TemplatesDatabase.ValuesDictionary dictionary) {
                PropertyDescriptor[] propertyDescriptors = new PropertyDescriptor[dictionary.Count];
                int index = 0;
                foreach (var item in dictionary) {
                    List<Attribute> attrs = [];
                    propertyDescriptors[index++] = new KeyValuePairPropertyDescriptor(item, attrs.ToArray());
                }
                return new PropertyDescriptorCollection(propertyDescriptors);
            }
            return null;
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context) {
            return true;
        }
    }

    public class KeyValuePairPropertyDescriptor : PropertyDescriptor {
        private KeyValuePair<string, object> pair;
        private Attribute[] attrs;

        public KeyValuePairPropertyDescriptor(KeyValuePair<string, object> pair, Attribute[] attrs)
            : base(pair.Key, null) {
            this.pair = pair;
            this.attrs = attrs;
        }

        public override Type ComponentType => typeof(object);

        public override Type PropertyType => pair.Value?.GetType() ?? typeof(object);

        public override bool IsReadOnly => true;

        public override bool CanResetValue(object component) {
            return false;
        }

        public override object GetValue(object component) {
            return pair.Value;
        }

        public override void ResetValue(object component) {
            // Do nothing
        }

        public override void SetValue(object component, object value) {
            // Do nothing
        }

        public override bool ShouldSerializeValue(object component) {
            return false;
        }

        public override AttributeCollection Attributes => new AttributeCollection(attrs);
    }

    public class ECSEditor : UITypeEditor {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value) {
            InspectorWindow? inspectorWindow = Program.MainForm.FindSubwindow<InspectorWindow>();
            if (inspectorWindow == null) {
                inspectorWindow = (InspectorWindow?)Program.MainForm.AddSubwindow(new InspectorWindow(), DarkUI.Docking.DarkDockArea.Bottom);
            }
            inspectorWindow.DisplayObject = new AutoBrowsableTypeDescriptor(TypeDescriptor.GetProvider(value).GetTypeDescriptor(value), value.GetType(), value, null);
            return value;
        }
    }
}
