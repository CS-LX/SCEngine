using DarkUI.Controls;

namespace SCEngine {
    partial class MatrixDialog {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        public void InitializeComponent() {
            matrixPanel = new TableLayoutPanel();
            SuspendLayout();
            // 
            // matrixPanel
            // 
            matrixPanel.ColumnCount = 4;
            matrixPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            matrixPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            matrixPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            matrixPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            matrixPanel.Dock = DockStyle.Fill;
            matrixPanel.Location = new Point(0, 0);
            matrixPanel.Name = "matrixPanel";
            matrixPanel.RowCount = 4;
            matrixPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            matrixPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            matrixPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            matrixPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            matrixPanel.Size = new Size(227, 176);
            matrixPanel.TabIndex = 0;
            // 
            // MatrixDialog
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(227, 176);
            Controls.Add(matrixPanel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MatrixDialog";
            Text = "ColorExDialog";
            ResumeLayout(false);
        }

        #endregion

        private DarkTextBox[] matrixInputs = new DarkTextBox[16];
        private TableLayoutPanel matrixPanel;
    }
}