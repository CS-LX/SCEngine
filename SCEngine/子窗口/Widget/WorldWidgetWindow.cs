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
using Game;
using System.Globalization;
using System.Reflection;
using DarkUI.Forms;
using GameEntitySystem;
using Screen = Game.Screen;
using System.Xml.Linq;
using XmlUtilities;
using Engine;
using System.Diagnostics;
using SCEngine.Properties;

namespace SCEngine {
    public partial class WorldWidgetWindow : DarkToolWindow {
        public WorldWidgetWindow() {
            InitializeComponent();
        }

        #region 字段
        public SubsystemPlayers subsystemPlayers;
        public ComponentGui componentGui;
        public ContainerWidget currentWidget;
        private List<Type> widgetsInToolBox = new List<Type>();//工具箱里有的，可以直接来用的、视为单体的界面
        private Type[] acceptChildWidgets = [typeof(CanvasWidget), typeof(StackPanelWidget), typeof(UniformSpacingPanelWidget)];
        #endregion

        #region 方法
        public void UpdateCurrentWidget() {
            //将玩家当前的界面更新到编辑窗口中
            if (!FindPlayer()) return;
            ContainerWidget currentWidget = componentGui.ModalPanelWidget is ContainerWidget widget ? widget : null;
            if (currentWidget == this.currentWidget) return;
            this.currentWidget = currentWidget;
            widgetView.Nodes.Clear();
            propertriesGrid.SelectedObject = null;
            if (currentWidget == null) return;

            //添加界面节点
            DarkTreeNode rootNode = new DarkTreeNode(CreateNodeName(currentWidget), currentWidget.GetType().Name);
            rootNode.Tag = currentWidget;
            UpdateWidgetNodes(currentWidget, rootNode);
            widgetView.Nodes.Add(rootNode);

        }

        private void UpdateWidgetNodes(ContainerWidget widget, DarkTreeNode parentNode) {//递归添加界面组件进入树状图
            if (widget == null || parentNode == null) return;

            foreach (Widget childWidget in widget.Children) {
                DarkTreeNode node = new DarkTreeNode(string.IsNullOrEmpty(childWidget.Name) ? $"[{childWidget.GetType().Name}]" : childWidget.Name, childWidget.GetType().Name);
                node.Tag = childWidget;
                parentNode.Nodes.Add(node);

                if (childWidget is ContainerWidget subContainerWidget) {
                    UpdateWidgetNodes(subContainerWidget, node);
                }
            }
        }

        public void UpdateToolBox() {
            Assembly assembly = Assembly.GetAssembly(typeof(Game.Program));
            widgetsInToolBox.Clear();
            var widgetTypes = new List<Type>();

            foreach (var type in assembly.GetTypes()) {
                if (UIUtils.CanInstantiate(type) &&
                    (type == typeof(Widget) || type.IsSubclassOf(typeof(Widget))) &&
                    !type.IsSubclassOf(typeof(Dialog)) &&
                    type != typeof(Dialog) &&
                    !type.IsSubclassOf(typeof(Screen)) &&
                    type != typeof(Screen)
                    ) {
                    widgetTypes.Add(type);
                }
            }

            foreach (var widgetType in widgetTypes) {
                DarkTreeNode darkTreeNode = new DarkTreeNode(UIUtils.TrimEnd(widgetType.Name, "Widget"));
                darkTreeNode.Tag = widgetType;
                toolBox.Nodes.Add(darkTreeNode);
                widgetsInToolBox.Add(widgetType);
            }
        }

        private bool FindPlayer() {//寻找玩家GUI，找到了就返回true
            if (GameManager.Project == null) return false;
            subsystemPlayers = GameManager.Project.FindSubsystem<SubsystemPlayers>();
            if (subsystemPlayers == null) return false;
            componentGui = subsystemPlayers.m_componentPlayers.FirstOrDefault()?.ComponentGui;
            return componentGui != null;
        }

        private void AddWidget(ContainerWidget parentWidget, Type type, out Widget newWidget) {
            newWidget = Activator.CreateInstance(type) as Widget;
            parentWidget.AddChildren(newWidget);
        }

        private string CreateNodeName(Widget widget) => string.IsNullOrEmpty(widget.Name) ? $"[{widget.GetType().Name}]" : widget.Name;

        public void ExportWidget(Widget widget, string path) {
            XElement rootElement = new XElement(widget.GetType().Name);
            if (widget is ContainerWidget rootContainerWidget) {
                foreach (var child in rootContainerWidget.Children) {
                    WidgetToXml(child, rootElement);
                }
            }

            using (Stream stream = Storage.OpenFile(@$"system:{path}", OpenFileMode.Create)) {
                XmlUtils.SaveXmlToStream(rootElement, stream, null, throwOnError: true);
            }
        }

        public void WidgetToXml(Widget widget, XElement parentElement) {
            //先获取界面属性的默认值
            Dictionary<string, object> defaultProps = new();
            Widget? emptyPropsWidget = (Widget?)(UIUtils.CanInstantiate(widget.GetType()) ? Activator.CreateInstance(widget.GetType()) : null);
            if (emptyPropsWidget != null) {
                PropertyInfo[] defaultPropsInfo = widget.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (PropertyInfo propInfo in defaultPropsInfo) {
                    if (!propInfo.CanRead ||
                        !propInfo.CanWrite ||
                        (propInfo.PropertyType.IsClass && !propInfo.PropertyType.Equals(typeof(string)))
                        ) continue;
                    defaultProps.Add(propInfo.Name, propInfo.GetValue(emptyPropsWidget));
                }
            }

            //再添加Xml节点
            XElement widgetElement = new XElement(widget.GetType().Name);
            parentElement.Add(widgetElement);

            //再添加属性
            PropertyInfo[] propertyInfos = widget.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo propInfo in propertyInfos) {
                if (!propInfo.CanRead ||
                    !propInfo.CanWrite ||
                    (propInfo.PropertyType.IsClass && !propInfo.PropertyType.Equals(typeof(string)))
                    ) continue;
                object? value = propInfo.GetValue(widget);
                object? defaultValue = null;
                if ((bool)(defaultProps?.ContainsKey(propInfo.Name))) defaultValue = defaultProps?[propInfo.Name];
                if (!Object.Equals(value, defaultValue) && value != null) {//如果界面的某一属性不等于它的默认值
                    XmlUtils.SetAttributeValue(widgetElement, propInfo.Name, value);
                }
            }

            //递归加载子元素（可是为单体界面的不添加子元素）
            if (widget is ContainerWidget container) {
                if (acceptChildWidgets.Contains(widget.GetType())) {
                    foreach (Widget childWidget in container.Children) {
                        WidgetToXml(childWidget, widgetElement);
                    }
                }
            }
        }
        #endregion

        #region UI事件
        private void updateTimer_Tick(object sender, EventArgs e) {
            UpdateCurrentWidget();
        }
        private void WorldWidgetWindow_Load(object sender, EventArgs e) {
            updateTimer.Enabled = true;
            UpdateToolBox();
        }
        private void widgetView_SelectedNodesChanged(object sender, EventArgs e) {
            propertriesGrid.SelectedObject = null;
            object? selectedObject = widgetView.SelectedNodes.FirstOrDefault()?.Tag ?? null;
            if (selectedObject != null) {
                // 使用自定义的 TypeConverter
                var typeDescriptor = new AutoBrowsableTypeDescriptor(TypeDescriptor.GetProvider(selectedObject).GetTypeDescriptor(selectedObject), selectedObject.GetType(), selectedObject);

                propertriesGrid.SelectedObject = typeDescriptor;
            }
        }
        private void toolBox_DoubleClick(object sender, EventArgs e) {
            try {
                object? selectedWidget = toolBox.SelectedNodes.FirstOrDefault()?.Tag ?? null;
                if (selectedWidget != null && selectedWidget is Type selectedWidgetType) {
                    object? selectedObject = widgetView.SelectedNodes.FirstOrDefault()?.Tag ?? null;
                    if (selectedObject != null) {
                        if (selectedObject is ContainerWidget containerWidget) {
                            //添加控件
                            AddWidget(containerWidget, selectedWidgetType, out Widget newWidget);
                            //添加节点
                            DarkTreeNode newNode = new DarkTreeNode(CreateNodeName(newWidget), newWidget.GetType().Name);
                            newNode.Tag = newWidget;
                            widgetView.SelectedNodes.FirstOrDefault()?.Nodes.Add(newNode);
                        }
                        else {
                            DarkMessageBox.ShowWarning($"无法添加子控件，因为{selectedObject}不是容器！", "无法操作");
                            return;
                        }
                    }
                }
            }
            catch (Exception ex) {
                DarkMessageBox.ShowWarning(ex.Message, "错误");
                return;
            }
        }
        private void removeWidgetButton_Click(object sender, EventArgs e) {
            object? selectedObject = widgetView.SelectedNodes.FirstOrDefault()?.Tag ?? null;
            if (selectedObject != null && selectedObject is Widget selectedWidget) {
                DarkTreeNode selectedNode = widgetView.SelectedNodes.FirstOrDefault();
                if (!selectedNode.IsRoot) {
                    selectedNode.ParentNode.Nodes.Remove(selectedNode);//删除节点
                    selectedWidget.ParentWidget.Children.Remove(selectedWidget);//删除界面
                }
                else {
                    DarkMessageBox.ShowWarning($"无法删除根控件", "无法操作");
                    return;
                }
            }
        }
        private void propertriesGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e) {
            if (e.ChangedItem?.Label == "Name") {
                if (propertriesGrid.SelectedObject is AutoBrowsableTypeDescriptor descriptor && descriptor._instance is Widget editingWidget) {
                    DarkTreeNode? selectedNode = widgetView.SelectedNodes?.FirstOrDefault();
                    if (selectedNode != null) selectedNode.Text = CreateNodeName(editingWidget);
                }
            }
        }
        private void exportXmlButton_Click(object sender, EventArgs e) {
            //try {
            string filePath = @"D:\Test.xml";
            ExportWidget(currentWidget, filePath);
            DarkMessageBox.ShowInformation("导出成功", "");
            Process.Start("explorer.exe", $"/select,\"{filePath}\"");
            //}
            //catch (Exception ex) {
            //    DarkMessageBox.ShowError($"导出失败\r\n\r\n错误如下：\r\n{ex}", "");
            //}
        }
        #endregion
    }
}
