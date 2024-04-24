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
using DarkUI.Config;

namespace SCEngine {
    public partial class StaticClassesWindow : DarkToolWindow {
        public StaticClassesWindow() {
            InitializeComponent();
        }

        public void UpdateClasses() {//更新实体
            Assembly assembly = Assembly.GetAssembly(typeof(Game.Program)); // 获取当前程序集

            var staticClasses = assembly.GetTypes().Where(t => t.IsClass && t.IsAbstract && t.IsSealed).ToList(); // 获取所有静态类

            foreach (Type staticType in staticClasses) {
                DarkListItem darkListItem = new DarkListItem(staticType.Name, staticType.Namespace);
                darkListItem.Tag = staticType;
                darkListItem.SubTextColor = Colors.DisabledText;
                staticClassesView.Items.Add(darkListItem);
            }

        }

        private void WorldSubsystemsWindow_Load(object sender, EventArgs e) {
            UpdateClasses();
        }

        private void searchButton_Click(object sender, EventArgs e) {//搜索功能
            if (staticClassesView.Items.Count == 0) return;
            DarkListItem perviousSelectedNode = staticClassesView.Items[staticClassesView.SelectedIndices.FirstOrDefault()];
            List<DarkListItem> tempNodes = new List<DarkListItem>(staticClassesView.Items);
            staticClassesView.Items.Clear();
            List<DarkListItem> lastNodes = new List<DarkListItem>();
            foreach (var node in tempNodes) {
                if (UIUtils.FuzzyMatch(node.Text, searchKeyBox.Text)) {
                    staticClassesView.Items.Add(node);
                    continue;
                }
                lastNodes.Add(node);
            }
            foreach (var node in lastNodes) {
                staticClassesView.Items.Add(node);
            }
            staticClassesView.SelectItem(staticClassesView.Items.IndexOf(perviousSelectedNode));
        }

        private void staticClassesView_SelectedIndicesChanged(object sender, EventArgs e) {
            propertriesGrid.SelectedObject = null;
            if (staticClassesView.Items.Count == 0) return;
            int index = staticClassesView.SelectedIndices.FirstOrDefault();
            object? selectedObject = staticClassesView.Items[index]?.Tag ?? null;
            if (selectedObject != null) {
                // 使用自定义的 TypeConverter
                var typeDescriptor = new StaticClassWrapper(selectedObject as Type);

                propertriesGrid.SelectedObject = typeDescriptor;
            }
        }
    }
}
