using DarkUI.Controls;

namespace SCEngine {
    partial class ColorExDialog {
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
            RInput = new DarkNumericUpDown();
            GInput = new DarkNumericUpDown();
            BInput = new DarkNumericUpDown();
            darkLabel = new DarkLabel();
            darkLabel1 = new DarkLabel();
            darkLabel2 = new DarkLabel();
            AInput = new DarkNumericUpDown();
            darkLabel3 = new DarkLabel();
            colorDisplayer = new Panel();
            ((System.ComponentModel.ISupportInitialize)RInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)GInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AInput).BeginInit();
            SuspendLayout();
            // 
            // RInput
            // 
            RInput.Location = new Point(50, 12);
            RInput.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            RInput.Name = "RInput";
            RInput.Size = new Size(144, 27);
            RInput.TabIndex = 2;
            RInput.ValueChanged += RInput_ValueChanged;
            RInput.KeyUp += RInput_KeyUp;
            // 
            // GInput
            // 
            GInput.Location = new Point(50, 45);
            GInput.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            GInput.Name = "GInput";
            GInput.Size = new Size(144, 27);
            GInput.TabIndex = 3;
            GInput.ValueChanged += GInput_ValueChanged;
            // 
            // BInput
            // 
            BInput.Location = new Point(50, 78);
            BInput.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            BInput.Name = "BInput";
            BInput.Size = new Size(144, 27);
            BInput.TabIndex = 4;
            BInput.ValueChanged += BInput_ValueChanged;
            // 
            // darkLabel
            // 
            darkLabel.ForeColor = Color.FromArgb(220, 220, 220);
            darkLabel.Location = new Point(15, 13);
            darkLabel.Name = "darkLabel";
            darkLabel.Size = new Size(29, 23);
            darkLabel.TabIndex = 5;
            darkLabel.Text = "R";
            darkLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // darkLabel1
            // 
            darkLabel1.ForeColor = Color.FromArgb(220, 220, 220);
            darkLabel1.Location = new Point(15, 46);
            darkLabel1.Name = "darkLabel1";
            darkLabel1.Size = new Size(29, 23);
            darkLabel1.TabIndex = 6;
            darkLabel1.Text = "G";
            darkLabel1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // darkLabel2
            // 
            darkLabel2.ForeColor = Color.FromArgb(220, 220, 220);
            darkLabel2.Location = new Point(15, 79);
            darkLabel2.Name = "darkLabel2";
            darkLabel2.Size = new Size(29, 23);
            darkLabel2.TabIndex = 7;
            darkLabel2.Text = "B";
            darkLabel2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // AInput
            // 
            AInput.Location = new Point(50, 111);
            AInput.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            AInput.Name = "AInput";
            AInput.Size = new Size(144, 27);
            AInput.TabIndex = 8;
            AInput.ValueChanged += AInput_ValueChanged;
            // 
            // darkLabel3
            // 
            darkLabel3.ForeColor = Color.FromArgb(220, 220, 220);
            darkLabel3.Location = new Point(15, 112);
            darkLabel3.Name = "darkLabel3";
            darkLabel3.Size = new Size(29, 23);
            darkLabel3.TabIndex = 9;
            darkLabel3.Text = "A";
            darkLabel3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // colorDisplayer
            // 
            colorDisplayer.Location = new Point(227, 13);
            colorDisplayer.Name = "colorDisplayer";
            colorDisplayer.Size = new Size(127, 125);
            colorDisplayer.TabIndex = 10;
            // 
            // ColorExDialog
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(369, 152);
            Controls.Add(colorDisplayer);
            Controls.Add(darkLabel3);
            Controls.Add(AInput);
            Controls.Add(darkLabel2);
            Controls.Add(darkLabel1);
            Controls.Add(BInput);
            Controls.Add(GInput);
            Controls.Add(RInput);
            Controls.Add(darkLabel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ColorExDialog";
            Text = "ColorExDialog";
            Controls.SetChildIndex(darkLabel, 0);
            Controls.SetChildIndex(RInput, 0);
            Controls.SetChildIndex(GInput, 0);
            Controls.SetChildIndex(BInput, 0);
            Controls.SetChildIndex(darkLabel1, 0);
            Controls.SetChildIndex(darkLabel2, 0);
            Controls.SetChildIndex(AInput, 0);
            Controls.SetChildIndex(darkLabel3, 0);
            Controls.SetChildIndex(colorDisplayer, 0);
            ((System.ComponentModel.ISupportInitialize)RInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)GInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)BInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)AInput).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DarkNumericUpDown RInput;
        private DarkNumericUpDown GInput;
        private DarkNumericUpDown BInput;
        private DarkLabel darkLabel;
        private DarkLabel darkLabel1;
        private DarkLabel darkLabel2;
        private DarkNumericUpDown AInput;
        private DarkLabel darkLabel3;
        private Panel colorDisplayer;
    }
}