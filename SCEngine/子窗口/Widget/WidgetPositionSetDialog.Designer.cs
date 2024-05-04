using DarkUI.Controls;

namespace SCEngine {
    partial class WidgetPositionSetDialog {
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
        private void InitializeComponent() {
            xBox = new DarkNumericUpDown();
            yBox = new DarkNumericUpDown();
            label1 = new DarkLabel();
            label2 = new DarkLabel();
            ((System.ComponentModel.ISupportInitialize)xBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)yBox).BeginInit();
            SuspendLayout();
            // 
            // btnOk
            // 
            btnOk.Margin = new Padding(0, 0, 10, 0);
            btnOk.Text = "确定";
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(137, 15);
            btnCancel.Text = "取消";
            // 
            // btnClose
            // 
            btnClose.Location = new Point(15, 15);
            // 
            // btnYes
            // 
            btnYes.Location = new Point(15, 15);
            // 
            // btnNo
            // 
            btnNo.Location = new Point(15, 15);
            // 
            // btnRetry
            // 
            btnRetry.Location = new Point(575, 15);
            // 
            // btnIgnore
            // 
            btnIgnore.Location = new Point(575, 15);
            // 
            // xBox
            // 
            xBox.Location = new Point(37, 12);
            xBox.Name = "xBox";
            xBox.Size = new Size(253, 27);
            xBox.TabIndex = 2;
            xBox.ValueChanged += xBox_ValueChanged;
            // 
            // yBox
            // 
            yBox.Location = new Point(37, 48);
            yBox.Name = "yBox";
            yBox.Size = new Size(253, 27);
            yBox.TabIndex = 3;
            yBox.ValueChanged += yBox_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.FromArgb(220, 220, 220);
            label1.Location = new Point(12, 14);
            label1.Name = "label1";
            label1.Size = new Size(19, 20);
            label1.TabIndex = 4;
            label1.Text = "X";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.FromArgb(220, 220, 220);
            label2.Location = new Point(12, 55);
            label2.Name = "label2";
            label2.Size = new Size(18, 20);
            label2.TabIndex = 5;
            label2.Text = "Y";
            // 
            // WidgetPositionSetDialog
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(302, 152);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(yBox);
            Controls.Add(xBox);
            DialogButtons = DarkUI.Forms.DarkDialogButton.OkCancel;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "WidgetPositionSetDialog";
            Text = "设置控件位置";
            Load += WidgetPositionSetDialog_Load;
            Controls.SetChildIndex(xBox, 0);
            Controls.SetChildIndex(yBox, 0);
            Controls.SetChildIndex(label1, 0);
            Controls.SetChildIndex(label2, 0);
            ((System.ComponentModel.ISupportInitialize)xBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)yBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DarkNumericUpDown xBox;
        private DarkNumericUpDown yBox;
        private DarkLabel label1;
        private DarkLabel label2;
    }
}