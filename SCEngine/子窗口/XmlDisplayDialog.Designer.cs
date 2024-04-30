namespace SCEngine {
    partial class XmlDisplayDialog {
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
            SuspendLayout();
            // 
            // btnOk
            // 
            btnOk.Text = "关闭";
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(15, 15);
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
            // XmlDisplayDialog
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(851, 535);
            Name = "XmlDisplayDialog";
            Text = "预览xml";
            ResumeLayout(false);
        }

        #endregion
    }
}