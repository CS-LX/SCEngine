using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DarkUI.Controls;
using DarkUI.Docking;
using Entity = GameEntitySystem.Entity;
using Component = GameEntitySystem.Component;
using Game;
using System.Globalization;
using System.Reflection;

namespace SCEngine {
    public partial class WorldEnititesWindow : DarkToolWindow {
        public WorldEnititesWindow() {
            InitializeComponent();
        }

        public void UpdateEnitites() {//更新实体
            object? selectedObject = entitiesView.SelectedNodes.FirstOrDefault()?.Tag ?? null;

            entitiesView.Nodes.Clear();
            if (Game.GameManager.Project == null) return;
            DarkTreeNode willSelectNode = null;
            foreach (Entity entity in Game.GameManager.Project.Entities) {
                try {
                    //实体
                    DarkTreeNode enitiyNode = new DarkTreeNode();
                    enitiyNode.Tag = entity;
                    string entitySummary = TryGetSummary(entity);
                    enitiyNode.Text = entity.GetType().Name + (entitySummary.Length > 0 ? $" ({entitySummary})" : string.Empty);
                    entitiesView.Nodes.Add(enitiyNode);
                    if (selectedObject == entity) willSelectNode = enitiyNode;

                    //组件
                    foreach (Component component in entity.Components) {
                        DarkTreeNode componentNode = new DarkTreeNode();
                        componentNode.Tag = component;
                        componentNode.Text = component.GetType().ToString();
                        enitiyNode.Nodes.Add(componentNode);
                        if (selectedObject == component) willSelectNode = componentNode;
                    }
                }
                catch { }
            }
            if (willSelectNode != null) entitiesView.SelectNode(willSelectNode);
        }

        private string TryGetSummary(Entity entity) {
            if (entity == null) return string.Empty;

            ComponentCreature componentCreature = entity.FindComponent<ComponentCreature>(false);
            if (componentCreature != null) return componentCreature.DisplayName;

            ComponentBlockEntity componentBlockEntity = entity.FindComponent<ComponentBlockEntity>(false);
            if (componentBlockEntity != null) return "方块实体";

            return string.Empty;
        }

        private void WorldEnititesWindow_Load(object sender, EventArgs e) {
            updateTimer.Enabled = autoUpdateChechBox.Checked;
        }

        private void updateTimer_Tick(object sender, EventArgs e) {
            UpdateEnitites();
        }

        private void updateButton_Click(object sender, EventArgs e) {
            UpdateEnitites();
        }

        private void autoUpdateChechBox_CheckedChanged(object sender, EventArgs e) {
            updateTimer.Enabled = autoUpdateChechBox.Checked;
        }

        private void entitiesView_SelectedNodesChanged(object sender, EventArgs e) {
            propertriesGrid.SelectedObject = null;
            object? selectedObject = entitiesView.SelectedNodes.FirstOrDefault()?.Tag ?? null;
            if (selectedObject != null) {
                // 使用自定义的 TypeConverter
                var typeDescriptor = new AutoBrowsableTypeDescriptor(TypeDescriptor.GetProvider(selectedObject).GetTypeDescriptor(selectedObject), selectedObject.GetType());

                propertriesGrid.SelectedObject = typeDescriptor;
            }
        }
    }

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
                _propertyDescriptors[prop.Name] = new PropertyPropertyDescriptor(prop);
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

            public override Type PropertyType => _property.PropertyType;

            public override bool CanResetValue(object component) => false;

            public override object GetValue(object component) => _property.GetValue(component);

            public override void ResetValue(object component) => throw new NotSupportedException();

            public override void SetValue(object component, object value) => _property.SetValue(component, value);

            public override bool ShouldSerializeValue(object component) => false;

            public override bool IsReadOnly => false;

            public override Type ComponentType => _property.DeclaringType;
        }

        private class FieldPropertyDescriptor : PropertyDescriptor {
            private readonly FieldInfo _field;

            public FieldPropertyDescriptor(FieldInfo field) : base(field.Name, null) {
                _field = field;
            }

            public override Type PropertyType => _field.FieldType;

            public override bool CanResetValue(object component) => false;

            public override object GetValue(object component) => _field.GetValue(component);

            public override void ResetValue(object component) => throw new NotSupportedException();

            public override void SetValue(object component, object value) => _field.SetValue(component, value);

            public override bool ShouldSerializeValue(object component) => false;

            public override bool IsReadOnly => false;

            public override Type ComponentType => _field.DeclaringType;
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
}
