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

namespace SCEngine {
    public partial class InspectorWindow : DarkToolWindow {
        public InspectorWindow() {
            InitializeComponent();
        }

        public void UpdateItems() {

            DarkListItem darkListItem = new DarkListItem();
        }
    }
}
