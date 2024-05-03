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
using DarkUI.Forms;
using Engine;
using Color = Engine.Color;

namespace SCEngine {
    public partial class MatrixDialog : DarkForm {
        public Matrix InitalMatrix { get; set; }
        public MatrixDialog() {
            InitializeComponent();
            Point startPoint = new Point(8, 8);
            for (int i = 0; i < 4; i++) {
                for (int j = 0; j < 4; j++) {
                    DarkTextBox darkTextBox = new DarkTextBox { Name = $"M{i}{j}", Dock = DockStyle.Fill };
                    matrixInputs[i * 4 + j] = darkTextBox;
                    darkTextBox.Validating += DarkTextBox_Validating;
                    matrixPanel.Controls.Add(darkTextBox);
                    matrixPanel.SetColumn(darkTextBox, j);
                    matrixPanel.SetRow(darkTextBox, i);
                }
            }
        }

        private void DarkTextBox_Validating(object? sender, EventArgs e) {
            if (sender is DarkTextBox textBox) {
                if (!float.TryParse(textBox.Text, out _)) {
                    DarkMessageBox.ShowError("请输入有效的浮点数！", "提示");
                    textBox.Focus();
                }
            }
        }

        public Matrix GetValue() {
            Matrix matrix;
            matrix.M11 = float.Parse(matrixInputs[0].Text);
            matrix.M12 = float.Parse(matrixInputs[1].Text);
            matrix.M13 = float.Parse(matrixInputs[2].Text);
            matrix.M14 = float.Parse(matrixInputs[3].Text);
            matrix.M21 = float.Parse(matrixInputs[4].Text);
            matrix.M22 = float.Parse(matrixInputs[5].Text);
            matrix.M23 = float.Parse(matrixInputs[6].Text);
            matrix.M24 = float.Parse(matrixInputs[7].Text);
            matrix.M31 = float.Parse(matrixInputs[8].Text);
            matrix.M32 = float.Parse(matrixInputs[9].Text);
            matrix.M33 = float.Parse(matrixInputs[10].Text);
            matrix.M34 = float.Parse(matrixInputs[11].Text);
            matrix.M41 = float.Parse(matrixInputs[12].Text);
            matrix.M42 = float.Parse(matrixInputs[13].Text);
            matrix.M43 = float.Parse(matrixInputs[14].Text);
            matrix.M44 = float.Parse(matrixInputs[15].Text);
            return matrix;
        }

        public void SetValue() {
            matrixInputs[0].Text = InitalMatrix.M11.ToString();
            matrixInputs[1].Text = InitalMatrix.M12.ToString();
            matrixInputs[2].Text = InitalMatrix.M13.ToString();
            matrixInputs[3].Text = InitalMatrix.M14.ToString();
            matrixInputs[4].Text = InitalMatrix.M21.ToString();
            matrixInputs[5].Text = InitalMatrix.M22.ToString();
            matrixInputs[6].Text = InitalMatrix.M23.ToString();
            matrixInputs[7].Text = InitalMatrix.M24.ToString();
            matrixInputs[8].Text = InitalMatrix.M31.ToString();
            matrixInputs[9].Text = InitalMatrix.M32.ToString();
            matrixInputs[10].Text = InitalMatrix.M33.ToString();
            matrixInputs[11].Text = InitalMatrix.M34.ToString();
            matrixInputs[12].Text = InitalMatrix.M41.ToString();
            matrixInputs[13].Text = InitalMatrix.M42.ToString();
            matrixInputs[14].Text = InitalMatrix.M43.ToString();
            matrixInputs[15].Text = InitalMatrix.M44.ToString();
        }
    }
}
