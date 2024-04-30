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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XmlDisplayDialog));
            xmlTextBox = new FastColoredTextBoxNS.FastColoredTextBox();
            ((System.ComponentModel.ISupportInitialize)xmlTextBox).BeginInit();
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
            // xmlTextBox
            // 
            xmlTextBox.AutoCompleteBracketsList = new char[]
    {
    '(',
    ')',
    '{',
    '}',
    '[',
    ']',
    '"',
    '"',
    '\'',
    '\''
    };
            xmlTextBox.AutoIndentCharsPatterns = "";
            xmlTextBox.AutoScrollMinSize = new Size(211, 54);
            xmlTextBox.BackBrush = null;
            xmlTextBox.CharHeight = 18;
            xmlTextBox.CharWidth = 10;
            xmlTextBox.CommentPrefix = null;
            xmlTextBox.DefaultMarkerSize = 8;
            xmlTextBox.DisabledColor = Color.FromArgb(100, 180, 180, 180);
            xmlTextBox.Dock = DockStyle.Fill;
            xmlTextBox.Font = new Font("Courier New", 9.75F);
            xmlTextBox.Hotkeys = resources.GetString("xmlTextBox.Hotkeys");
            xmlTextBox.IsReplaceMode = false;
            xmlTextBox.Language = FastColoredTextBoxNS.Language.XML;
            xmlTextBox.LeftBracket = '<';
            xmlTextBox.LeftBracket2 = '(';
            xmlTextBox.Location = new Point(0, 0);
            xmlTextBox.Name = "xmlTextBox";
            xmlTextBox.Paddings = new Padding(0);
            xmlTextBox.ReadOnly = true;
            xmlTextBox.RightBracket = '>';
            xmlTextBox.RightBracket2 = ')';
            xmlTextBox.SelectionColor = Color.FromArgb(60, 0, 0, 255);
            xmlTextBox.ServiceColors = (FastColoredTextBoxNS.ServiceColors)resources.GetObject("xmlTextBox.ServiceColors");
            xmlTextBox.Size = new Size(851, 466);
            xmlTextBox.TabIndex = 2;
            xmlTextBox.Text = "<AAA>\r\n  <BBB XXX=\"CCC\"/>\r\n</AAA>";
            xmlTextBox.Zoom = 100;
            // 
            // XmlDisplayDialog
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(851, 535);
            Controls.Add(xmlTextBox);
            Name = "XmlDisplayDialog";
            Text = "预览xml";
            Controls.SetChildIndex(xmlTextBox, 0);
            ((System.ComponentModel.ISupportInitialize)xmlTextBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private FastColoredTextBoxNS.FastColoredTextBox xmlTextBox;
    }
}