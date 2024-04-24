using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SCEngine {
    public class StaticClassWrapper : ICustomTypeDescriptor {
        private readonly Type staticClassType;

        public StaticClassWrapper(Type staticClassType) {
            this.staticClassType = staticClassType;
        }

        public AttributeCollection GetAttributes() => TypeDescriptor.GetAttributes(this, true);

        public string GetClassName() => TypeDescriptor.GetClassName(this, true);

        public string GetComponentName() => TypeDescriptor.GetComponentName(this, true);

        public TypeConverter GetConverter() => TypeDescriptor.GetConverter(this, true);

        public EventDescriptor GetDefaultEvent() => TypeDescriptor.GetDefaultEvent(this, true);

        public PropertyDescriptor GetDefaultProperty() => null;

        public object GetEditor(Type editorBaseType) => TypeDescriptor.GetEditor(this, editorBaseType, true);

        public EventDescriptorCollection GetEvents() => TypeDescriptor.GetEvents(this, true);

        public EventDescriptorCollection GetEvents(Attribute[] attributes) => TypeDescriptor.GetEvents(this, attributes, true);

        public PropertyDescriptorCollection GetProperties() => GetProperties(new Attribute[0]);

        public PropertyDescriptorCollection GetProperties(Attribute[] attributes) {
            PropertyInfo[] properties = staticClassType.GetProperties(BindingFlags.Public | BindingFlags.Static);
            PropertyDescriptor[] propertyDescriptors = new PropertyDescriptor[properties.Length];
            for (int i = 0; i < properties.Length; i++) {
                propertyDescriptors[i] = new StaticClassPropertyDescriptor(properties[i]);
            }
            return new PropertyDescriptorCollection(propertyDescriptors);
        }

        public object GetPropertyOwner(PropertyDescriptor pd) => this;

        private class StaticClassPropertyDescriptor : PropertyDescriptor {
            private readonly PropertyInfo property;

            public StaticClassPropertyDescriptor(PropertyInfo property) : base(property.Name, null) {
                this.property = property;
            }

            public override Type ComponentType => typeof(StaticClassWrapper);

            public override Type PropertyType => property.PropertyType;

            public override bool IsReadOnly => !property.CanWrite;

            public override object GetValue(object component) => property.GetValue(null);

            public override void SetValue(object component, object value) => property.SetValue(null, value);

            public override bool CanResetValue(object component) => false;

            public override void ResetValue(object component) { }

            public override bool ShouldSerializeValue(object component) => false;
        }
    }
}
