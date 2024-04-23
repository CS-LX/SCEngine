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
using GameEntitySystem;

namespace SCEngine {
    public partial class WorldSubsystemsWindow : DarkToolWindow {
        public WorldSubsystemsWindow() {
            InitializeComponent();
        }

        public void UpdateEnitites() {//更新实体
            if (Game.GameManager.Project == null) return;

            //如果存在project里面有而view里面没有的实体，就添加
            var tempSubsystems = GameManager.Project.Subsystems.ToList();
            foreach (Subsystem subsystem in tempSubsystems) {
                try {
                    bool hasContains = subsystemsView.Nodes.Any(node => node.Tag == subsystem);

                    if (!hasContains) {
                        DarkTreeNode subsystemNode = new DarkTreeNode();
                        subsystemNode.Tag = subsystem;
                        subsystemNode.Text = subsystem.GetType().Name;
                        subsystemsView.Nodes.Add(subsystemNode);
                    }

                }
                catch {
                    continue;
                }
            }

            var tempPreviousNodes = subsystemsView.Nodes.ToList();
            foreach (DarkTreeNode previousNode in tempPreviousNodes) {
                if (!GameManager.Project.Subsystems.Contains(previousNode.Tag)) subsystemsView.Nodes.Remove(previousNode);
            }

        }

        private void WorldSubsystemsWindow_Load(object sender, EventArgs e) {
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
            object? selectedObject = subsystemsView.SelectedNodes.FirstOrDefault()?.Tag ?? null;
            if (selectedObject != null) {
                // 使用自定义的 TypeConverter
                var typeDescriptor = new AutoBrowsableTypeDescriptor(TypeDescriptor.GetProvider(selectedObject).GetTypeDescriptor(selectedObject), selectedObject.GetType(), selectedObject);

                propertriesGrid.SelectedObject = typeDescriptor;
            }
        }
    }
}
