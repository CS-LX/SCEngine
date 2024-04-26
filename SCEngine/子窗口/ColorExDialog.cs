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
using Color = Engine.Color;

namespace SCEngine {
    public partial class ColorExDialog : DarkForm {
        public Color SelectedColor => new((int)RInput.Value, (int)GInput.Value, (int)BInput.Value, (int)AInput.Value);
        private Color _initalColor = Color.Black;
        public Color InitalColor {
            get => _initalColor;
            set {
                _initalColor = value;
                AInput.Value = InitalColor.A;
                RInput.Value = InitalColor.R;
                GInput.Value = InitalColor.G;
                BInput.Value = InitalColor.B;
                colorDisplayer.BackColor = System.Drawing.Color.FromArgb((int)AInput.Value, (int)RInput.Value, (int)GInput.Value, (int)BInput.Value);
            }
        }
        public ColorExDialog() {
            InitializeComponent();
            AInput.Value = InitalColor.A;
            RInput.Value = InitalColor.R;
            GInput.Value = InitalColor.G;
            BInput.Value = InitalColor.B;
            colorDisplayer.BackColor = System.Drawing.Color.FromArgb((int)AInput.Value, (int)RInput.Value, (int)GInput.Value, (int)BInput.Value);
        }

        private void AInput_ValueChanged(object sender, EventArgs e) {
            colorDisplayer.BackColor = System.Drawing.Color.FromArgb((int)AInput.Value, (int)RInput.Value, (int)GInput.Value, (int)BInput.Value);
        }

        private void BInput_ValueChanged(object sender, EventArgs e) {
            colorDisplayer.BackColor = System.Drawing.Color.FromArgb((int)AInput.Value, (int)RInput.Value, (int)GInput.Value, (int)BInput.Value);
        }

        private void GInput_ValueChanged(object sender, EventArgs e) {
            colorDisplayer.BackColor = System.Drawing.Color.FromArgb((int)AInput.Value, (int)RInput.Value, (int)GInput.Value, (int)BInput.Value);
        }

        private void RInput_ValueChanged(object sender, EventArgs e) {
            colorDisplayer.BackColor = System.Drawing.Color.FromArgb((int)AInput.Value, (int)RInput.Value, (int)GInput.Value, (int)BInput.Value);
        }

        private void RInput_KeyUp(object sender, KeyEventArgs e) {
            colorDisplayer.BackColor = System.Drawing.Color.FromArgb((int)AInput.Value, (int)RInput.Value, (int)GInput.Value, (int)BInput.Value);
        }

        private void GInput_KeyUp(object sender, KeyEventArgs e) {
            colorDisplayer.BackColor = System.Drawing.Color.FromArgb((int)AInput.Value, (int)RInput.Value, (int)GInput.Value, (int)BInput.Value);
        }

        private void BInput_KeyUp(object sender, KeyEventArgs e) {
            colorDisplayer.BackColor = System.Drawing.Color.FromArgb((int)AInput.Value, (int)RInput.Value, (int)GInput.Value, (int)BInput.Value);
        }

        private void AInput_KeyUp(object sender, KeyEventArgs e) {
            colorDisplayer.BackColor = System.Drawing.Color.FromArgb((int)AInput.Value, (int)RInput.Value, (int)GInput.Value, (int)BInput.Value);
        }
    }
}
