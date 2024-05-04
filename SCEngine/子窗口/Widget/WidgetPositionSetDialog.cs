using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DarkUI.Forms;
using Engine;

namespace SCEngine {
    public partial class WidgetPositionSetDialog : DarkDialog {
        public Vector2 Position { get; set; }
        public Action<Vector2> OnValueChanged { get; set; }

        public WidgetPositionSetDialog(Vector2 position, Action<Vector2> onValueChanged) {
            InitializeComponent();
            Position = position;
            xBox.Minimum = decimal.MinValue;
            xBox.Maximum = decimal.MaxValue;
            yBox.Minimum = decimal.MinValue;
            yBox.Maximum = decimal.MaxValue;
            OnValueChanged = onValueChanged;
        }
        private void WidgetPositionSetDialog_Load(object sender, EventArgs e) {
            xBox.Value = (decimal)Position.X;
            yBox.Value = (decimal)Position.Y;
        }

        private void xBox_ValueChanged(object sender, EventArgs e) {
            Position = new Vector2((float)xBox.Value, Position.Y);
            OnValueChanged?.Invoke(Position);
        }

        private void yBox_ValueChanged(object sender, EventArgs e) {
            Position = new Vector2(Position.X, (float)yBox.Value);
            OnValueChanged?.Invoke(Position);
        }
    }
}
