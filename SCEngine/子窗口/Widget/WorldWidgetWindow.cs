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
using Jint.Native;
using System.Xml;
using DarkUI.Config;
using DarkUI.Collections;

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
        //界面是否导出为xml
        private Dictionary<Widget, bool> widgetExportEnable = new Dictionary<Widget, bool>();
        private List<Widget> userSelectedExportEnable = new List<Widget>();//用户指定的可以导出xml的界面
        private string filePath = "";
        #endregion

        #region 方法
        public void UpdateCurrentWidget() {
            //将玩家当前的界面更新到编辑窗口中
            if (!FindPlayer()) return;
            ContainerWidget currentWidget = componentGui.ModalPanelWidget is ContainerWidget widget ? widget : null;
            if (currentWidget == this.currentWidget) return;
            this.currentWidget = currentWidget;
            widgetView.SelectedNodes.Clear();
            widgetView.Nodes.Clear();
            propertriesGrid.SelectedObject = null;
            if (currentWidget == null) return;

            //添加界面节点
            DarkTreeNode rootNode = new DarkTreeNode(CreateNodeName(currentWidget), currentWidget.GetType().Name);
            rootNode.Tag = currentWidget;
            UpdateWidgetNodes(currentWidget, rootNode);
            widgetView.Nodes.Add(rootNode);

            UpdateWidgetEnables(currentWidget, true, true);
            UpdateNodeStates(widgetView.Nodes);
        }

        public void UpdateControls() {
            viewXmlButton.Enabled = currentWidget != null;
            exportXmlButton.Enabled = currentWidget != null;

            enableXmlExportButton.Enabled = currentWidget != null && widgetView.SelectedNodes.FirstOrDefault()?.Tag != null;
            removeWidgetButton.Enabled = currentWidget != null && widgetView.SelectedNodes.FirstOrDefault()?.Tag != null;
            positionSetButton.Enabled = currentWidget != null && widgetView.SelectedNodes.FirstOrDefault()?.Tag != null;

            newWidgetButton.Enabled = componentGui != null;
            importButton.Enabled = componentGui != null;
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

        public void ExportWidget(Widget widget, string path, string rootNodeName) {
            XElement rootElement = new XElement(XName.Get(rootNodeName, "runtime-namespace:" + widget.GetType().Namespace));
            if (widget is ContainerWidget rootContainerWidget) {
                foreach (var child in rootContainerWidget.Children) {
                    WidgetToXml(child, rootElement, widget is CanvasWidget canvasWidget ? canvasWidget.m_positions : null);
                }
            }

            using (Stream stream = Storage.OpenFile(@$"system:{path}", OpenFileMode.Create)) {
                XmlUtils.SaveXmlToStream(rootElement, stream, null, throwOnError: true);
            }
        }
        public string EncodeWidget(Widget widget) {//界面转为xml
            XElement rootElement = new XElement(XName.Get(widget.GetType().Name, "runtime-namespace:" + widget.GetType().Namespace));
            if (widget is ContainerWidget rootContainerWidget) {
                foreach (var child in rootContainerWidget.Children) {
                    WidgetToXml(child, rootElement, widget is CanvasWidget canvasWidget ? canvasWidget.m_positions : null);
                }
            }
            return XmlUtils.SaveXmlToString(rootElement, true);
        }

        public void WidgetToXml(Widget widget, XElement parentElement, Dictionary<Widget, Vector2>? widgetPositions = null) {
            if (!widgetExportEnable[widget]) return;
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
            XElement widgetElement = new XElement(XName.Get(widget.GetType().Name, "runtime-namespace:" + widget.GetType().Namespace));
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

            //再设置位置
            if (widgetPositions != null) {
                if (widgetPositions.Keys.Contains(widget)) {
                    XmlUtils.SetAttributeValue(widgetElement, "CanvasWidget.Position", widgetPositions[widget]);
                }
            }

            //递归加载子元素（可是为单体界面的不添加子元素）
            if (widget is ContainerWidget container) {
                //if (acceptChildWidgets.Contains(widget.GetType())) {
                foreach (Widget childWidget in container.Children) {
                    WidgetToXml(childWidget, widgetElement);
                }
                //}
            }
        }

        public void UpdateNodeStates(ObservableList<DarkTreeNode> rootNodes) {
            foreach (DarkTreeNode node in rootNodes) {
                node.FontColor = widgetExportEnable[node.Tag as Widget] ? Colors.LightText : Colors.DisabledText;

                UpdateNodeStates(node.Nodes);
            }
            widgetView.Focus();//将焦点打到界面列表里，强制更新节点状态
        }

        public void UpdateWidgetEnables(Widget widget, bool thisEnable, bool parentEnable) {//程序根据界面关系以及节点结构自动更新界面是否可导出为xml的属性
            bool childEnable = widget is ContainerWidget ? acceptChildWidgets.Contains(widget.GetType()) : true;
            if (widget == currentWidget) childEnable = true;

            bool enable = thisEnable && parentEnable;//这个界面是否可以导出xml的两个条件：父界面可以导出，此界面自己可以导出
            if (userSelectedExportEnable.Contains(widget)) enable = true;//用户指定了这个界面必须导出为xml，咱就不自动设置，听用户的

            if (widgetExportEnable.ContainsKey(widget)) {
                widgetExportEnable[widget] = enable;
            }
            else widgetExportEnable.Add(widget, enable);

            if (widget is ContainerWidget container) {
                foreach (Widget childWidget in container.Children) {
                    UpdateWidgetEnables(childWidget, childEnable, thisEnable);
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
            updateControlsTimer.Enabled = true;
            UpdateToolBox();
        }
        private void widgetView_SelectedNodesChanged(object sender, EventArgs e) {
            propertriesGrid.SelectedObject = null;
            object? selectedObject = widgetView.SelectedNodes.FirstOrDefault()?.Tag ?? null;
            if (selectedObject != null) {
                // 使用自定义的 TypeConverter
                var typeDescriptor = new AutoBrowsableTypeDescriptor(TypeDescriptor.GetProvider(selectedObject).GetTypeDescriptor(selectedObject), selectedObject.GetType(), selectedObject, null);

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

                            UpdateWidgetEnables(currentWidget, true, true);
                            UpdateNodeStates(widgetView.Nodes);
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
#if !DEBUG
            try {
#endif
            WidgetExportXmlDialog dialog = new WidgetExportXmlDialog();
            dialog.XmlPath = filePath;
            dialog.RootNodeText = currentWidget.GetType().Name;
            if (dialog.ShowDialog() == DialogResult.OK) {
                ExportWidget(currentWidget, dialog.XmlPath, dialog.RootNodeText);
                DarkMessageBox.ShowInformation("导出成功", "");
                Process.Start("explorer.exe", $"/select,\"{dialog.XmlPath}\"");
            }
#if !DEBUG
            }
            catch (Exception ex) {
                DarkMessageBox.ShowError($"导出失败\r\n\r\n错误如下：\r\n{ex}", "");
            }
#endif
        }
        private void enableXmlExportButton_Click(object sender, EventArgs e) {
            object? selectedObject = widgetView.SelectedNodes.FirstOrDefault()?.Tag ?? null;
            if (selectedObject != null && selectedObject is Widget selectedWidget) {
                //切换界面可导出为xml的状态
                if (userSelectedExportEnable.Contains(selectedWidget)) userSelectedExportEnable.Remove(selectedWidget);
                else userSelectedExportEnable.Add(selectedWidget);

                UpdateWidgetEnables(currentWidget, true, true);
                UpdateNodeStates(widgetView.Nodes);
            }
        }
        private void newWidgetButton_Click(object sender, EventArgs e) {
            CanvasWidget canvasWidget = new CanvasWidget();
            BevelledRectangleWidget rectangleWidget = new BevelledRectangleWidget { Size = new Vector2(360, 240), HorizontalAlignment = WidgetAlignment.Center, VerticalAlignment = WidgetAlignment.Center };
            canvasWidget.Children.Add(rectangleWidget);
            if (componentGui != null) componentGui.ModalPanelWidget = canvasWidget;
        }
        private void viewXmlButton_Click(object sender, EventArgs e) {
#if !DEBUG
            try {
#endif
            XmlDisplayDialog xmlDisplayDialog = new XmlDisplayDialog(EncodeWidget(currentWidget));
            xmlDisplayDialog.ShowDialog();
#if !DEBUG
            }
            catch (Exception ex) {
                DarkMessageBox.ShowError($"导出失败\r\n\r\n错误如下：\r\n{ex}", "");
            }
#endif
        }
        private void updateControlsTimer_Tick(object sender, EventArgs e) {
            UpdateControls();
        }
        private void importButton_Click(object sender, EventArgs e) {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Xml files (*.xml)|*.xml|All files (*.*)|*.*";
            openFileDialog.Title = "选择界面的xml文件";
            try {
                if (openFileDialog.ShowDialog() == DialogResult.OK) {
                    filePath = Path.GetFullPath(openFileDialog.FileName);
                    using (FileStream fileStream = new FileStream(filePath, FileMode.Open)) {
                        CanvasWidget canvasWidget = new CanvasWidget();
                        XElement node = XElement.Load(fileStream);
                        canvasWidget.LoadChildren(canvasWidget, node);
                        if (componentGui != null) componentGui.ModalPanelWidget = canvasWidget;
                    }
                }
            }
            catch (Exception ex) {
                DarkMessageBox.ShowError($"导入失败\r\n\r\n错误如下：\r\n{ex}", "");
            }
        }
        private void positionSetButton_Click(object sender, EventArgs e) {
            object? selectedObject = widgetView.SelectedNodes.FirstOrDefault()?.Tag ?? null;
            if (selectedObject != null && selectedObject is Widget selectedWidget && currentWidget is CanvasWidget canvasWidget) {
                if (!canvasWidget.m_positions.ContainsKey(selectedWidget)) {
                    Vector2 position = Vector2.Zero;
                    canvasWidget.m_positions.Add(selectedWidget, position);
                }
                Vector2 previousPos = canvasWidget.m_positions[selectedWidget];
                WidgetPositionSetDialog positionSetDialog = new WidgetPositionSetDialog(canvasWidget.m_positions[selectedWidget], (Vector2 pos) => {
                    canvasWidget.m_positions[selectedWidget] = pos;
                });
                if (positionSetDialog.ShowDialog() == DialogResult.Cancel) {//取消，还原之前位置
                    canvasWidget.m_positions[selectedWidget] = previousPos;
                }
            }
        }
        #endregion
    }
}
