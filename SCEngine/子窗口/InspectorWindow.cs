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
        private object displayObject;
        public object DisplayObject {
            get => displayObject;
            set {
                propertriesGrid.SelectedObject = null;
                displayObject = value;
                if (displayObject != null) {
                    propertriesGrid.SelectedObject = displayObject;
                }
            }
        }
        public InspectorWindow() {
            InitializeComponent();
        }
    }
}
