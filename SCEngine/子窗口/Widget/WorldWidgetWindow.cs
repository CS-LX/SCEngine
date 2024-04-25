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

namespace SCEngine {
    public partial class WorldWidgetWindow : DarkToolWindow {
        public WorldWidgetWindow() {
            InitializeComponent();
        }

        #region 字段
        public SubsystemPlayers subsystemPlayers;
        public ComponentGui componentGui;
        public ContainerWidget currentWidget;
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
            DarkTreeNode rootNode = new DarkTreeNode(string.IsNullOrEmpty(currentWidget.Name) ? currentWidget.GetType().Name : currentWidget.Name, currentWidget.GetType().Name);
            rootNode.Tag = currentWidget;
            rootNode.Expanded = true;
            UpdateWidgetNodes(currentWidget, rootNode);
            widgetView.Nodes.Add(rootNode);

        }

        private void UpdateWidgetNodes(ContainerWidget widget, DarkTreeNode parentNode) {//递归添加界面组件进入树状图
            if (widget == null || parentNode == null) return;

            foreach (Widget childWidget in widget.Children) {
                DarkTreeNode node = new DarkTreeNode(string.IsNullOrEmpty(childWidget.Name) ? childWidget.GetType().Name : childWidget.Name, childWidget.GetType().Name);
                node.Tag = childWidget;
                parentNode.Nodes.Add(node);

                if (childWidget is ContainerWidget subContainerWidget) {
                    UpdateWidgetNodes(subContainerWidget, node);
                }
            }
        }

        private bool FindPlayer() {//寻找玩家GUI，找到了就返回true
            if (GameManager.Project == null) return false;
            subsystemPlayers = GameManager.Project.FindSubsystem<SubsystemPlayers>();
            if (subsystemPlayers == null) return false;
            componentGui = subsystemPlayers.m_componentPlayers[0].ComponentGui;
            return true;
        }
        #endregion

        #region UI事件
        private void updateTimer_Tick(object sender, EventArgs e) {
            UpdateCurrentWidget();
        }
        private void WorldWidgetWindow_Load(object sender, EventArgs e) {
            updateTimer.Enabled = true;
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
        #endregion
    }
}
