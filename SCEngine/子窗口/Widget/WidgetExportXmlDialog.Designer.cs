using DarkUI.Controls;

namespace SCEngine {
    partial class WidgetExportXmlDialog {
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
            rootNodeTextbox = new DarkTextBox();
            chooesPathButton = new DarkButton();
            label1 = new DarkLabel();
            pathTextbox = new DarkTextBox();
            darkLabel1 = new DarkLabel();
            SuspendLayout();
            // 
            // btnOk
            // 
            btnOk.DialogResult = DialogResult.None;
            btnOk.Margin = new Padding(0, 0, 10, 0);
            btnOk.Text = "导出";
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(137, 15);
            btnCancel.Text = "取消";
            btnCancel.Click += btnCancel_Click;
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
            // rootNodeTextbox
            // 
            rootNodeTextbox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            rootNodeTextbox.BackColor = Color.FromArgb(69, 73, 74);
            rootNodeTextbox.BorderStyle = BorderStyle.FixedSingle;
            rootNodeTextbox.ForeColor = Color.FromArgb(220, 220, 220);
            rootNodeTextbox.Location = new Point(125, 12);
            rootNodeTextbox.Name = "rootNodeTextbox";
            rootNodeTextbox.Size = new Size(386, 27);
            rootNodeTextbox.TabIndex = 2;
            // 
            // chooesPathButton
            // 
            chooesPathButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            chooesPathButton.CenterIcon = null;
            chooesPathButton.CenterIconScale = 1F;
            chooesPathButton.Location = new Point(442, 48);
            chooesPathButton.Name = "chooesPathButton";
            chooesPathButton.Padding = new Padding(5);
            chooesPathButton.Size = new Size(69, 27);
            chooesPathButton.TabIndex = 3;
            chooesPathButton.Text = "指定";
            chooesPathButton.Click += chooesPathButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.FromArgb(220, 220, 220);
            label1.Location = new Point(12, 14);
            label1.Name = "label1";
            label1.Size = new Size(84, 20);
            label1.TabIndex = 4;
            label1.Text = "根节点名称";
            // 
            // pathTextbox
            // 
            pathTextbox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pathTextbox.BackColor = Color.FromArgb(69, 73, 74);
            pathTextbox.BorderStyle = BorderStyle.FixedSingle;
            pathTextbox.ForeColor = Color.FromArgb(220, 220, 220);
            pathTextbox.Location = new Point(125, 48);
            pathTextbox.Name = "pathTextbox";
            pathTextbox.Size = new Size(311, 27);
            pathTextbox.TabIndex = 5;
            pathTextbox.Validating += pathTextbox_Validating;
            // 
            // darkLabel1
            // 
            darkLabel1.AutoSize = true;
            darkLabel1.ForeColor = Color.FromArgb(220, 220, 220);
            darkLabel1.Location = new Point(12, 49);
            darkLabel1.Name = "darkLabel1";
            darkLabel1.Size = new Size(69, 20);
            darkLabel1.TabIndex = 6;
            darkLabel1.Text = "导出目录";
            // 
            // WidgetExportXmlDialog
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(523, 155);
            Controls.Add(darkLabel1);
            Controls.Add(pathTextbox);
            Controls.Add(label1);
            Controls.Add(chooesPathButton);
            Controls.Add(rootNodeTextbox);
            DialogButtons = DarkUI.Forms.DarkDialogButton.OkCancel;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "WidgetExportXmlDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "导出为xml";
            Controls.SetChildIndex(rootNodeTextbox, 0);
            Controls.SetChildIndex(chooesPathButton, 0);
            Controls.SetChildIndex(label1, 0);
            Controls.SetChildIndex(pathTextbox, 0);
            Controls.SetChildIndex(darkLabel1, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DarkTextBox rootNodeTextbox;
        private DarkButton chooesPathButton;
        private DarkLabel label1;
        private DarkTextBox pathTextbox;
        private DarkLabel darkLabel1;
    }
}