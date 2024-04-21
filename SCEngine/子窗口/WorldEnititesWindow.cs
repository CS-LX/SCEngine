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
                propertriesGrid.SelectedObject = selectedObject;
            }
        }
    }
}
