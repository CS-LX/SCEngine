namespace SCEngine {
    partial class InspectorWindow {
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
            propertriesGrid = new PropertyGridSC();
            SuspendLayout();
            // 
            // propertriesGrid
            // 
            propertriesGrid.CategoryForeColor = Color.FromArgb(122, 128, 132);
            propertriesGrid.CategorySplitterColor = Color.FromArgb(51, 51, 51);
            propertriesGrid.CommandsBorderColor = Color.FromArgb(51, 51, 51);
            propertriesGrid.CommandsForeColor = Color.FromArgb(122, 128, 132);
            propertriesGrid.DisabledItemForeColor = Color.FromArgb(127, 122, 128, 132);
            propertriesGrid.Dock = DockStyle.Fill;
            propertriesGrid.DrawFlat = true;
            propertriesGrid.EnableSerializable = false;
            propertriesGrid.EnableXmlSerializable = false;
            propertriesGrid.HelpBackColor = Color.FromArgb(60, 63, 65);
            propertriesGrid.HelpBorderColor = Color.FromArgb(51, 51, 51);
            propertriesGrid.HelpForeColor = Color.Gainsboro;
            propertriesGrid.LineColor = Color.FromArgb(51, 51, 51);
            propertriesGrid.Location = new Point(0, 25);
            propertriesGrid.Name = "propertriesGrid";
            propertriesGrid.SelectedItemWithFocusBackColor = Color.FromArgb(69, 73, 74);
            propertriesGrid.SelectedItemWithFocusForeColor = Color.White;
            propertriesGrid.Size = new Size(800, 436);
            propertriesGrid.TabIndex = 1;
            propertriesGrid.ViewBackColor = Color.FromArgb(60, 63, 65);
            propertriesGrid.ViewBorderColor = Color.FromArgb(51, 51, 51);
            propertriesGrid.ViewForeColor = Color.Gainsboro;
            // 
            // InspectorWindow
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(propertriesGrid);
            DefaultDockArea = DarkUI.Docking.DarkDockArea.Document;
            DockText = "检查器";
            Name = "InspectorWindow";
            Size = new Size(800, 461);
            ResumeLayout(false);
        }

        #endregion

        private PropertyGridSC propertriesGrid;
    }
}