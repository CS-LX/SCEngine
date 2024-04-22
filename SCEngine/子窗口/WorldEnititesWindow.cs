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
using DarkUI.Forms;

namespace SCEngine {
    public partial class WorldEnititesWindow : DarkToolWindow {
        public WorldEnititesWindow() {
            InitializeComponent();
        }

        public void UpdateEnitites() {//更新实体
            if (Game.GameManager.Project == null) return;

            //如果存在project里面有而view里面没有的实体，就添加
            var tempEntities = GameManager.Project.Entities.ToList();
            foreach (Entity entity in tempEntities) {
                try {
                    bool hasContains = entitiesView.Nodes.Any(node => node.Tag == entity);

                    if (!hasContains) {
                        //实体
                        DarkTreeNode enitiyNode = new DarkTreeNode();
                        enitiyNode.Tag = entity;
                        string entitySummary = TryGetSummary(entity);
                        enitiyNode.Text = entitySummary;
                        entitiesView.Nodes.Add(enitiyNode);

                        //组件
                        foreach (Component component in entity.Components) {
                            DarkTreeNode componentNode = new DarkTreeNode();
                            componentNode.Tag = component;
                            componentNode.Text = component.GetType().ToString();
                            enitiyNode.Nodes.Add(componentNode);
                        }
                    }

                }
                catch {
                    continue;
                }
            }

            var tempPreviousNodes = entitiesView.Nodes.ToList();
            foreach (DarkTreeNode previousNode in tempPreviousNodes) {
                if (!GameManager.Project.Entities.Contains(previousNode.Tag)) entitiesView.Nodes.Remove(previousNode);
            }

        }

        private string TryGetSummary(Entity entity) {
            if (entity == null) return string.Empty;

            ComponentCreature componentCreature = entity.FindComponent<ComponentCreature>(false);
            if (componentCreature != null) return componentCreature.DisplayName;

            ComponentBlockEntity componentBlockEntity = entity.FindComponent<ComponentBlockEntity>(false);
            if (componentBlockEntity != null) return "方块实体";

            ComponentIntroShip componentIntroShip = entity.FindComponent<ComponentIntroShip>(false);
            if (componentIntroShip != null) return "初始船";

            return "未知实体";
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
}
