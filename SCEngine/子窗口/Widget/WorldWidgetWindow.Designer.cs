using href.Controls.PropGridEx;

namespace SCEngine {
    partial class WorldWidgetWindow {
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
            updateTimer = new System.Windows.Forms.Timer(components);
            widgetView = new DarkUI.Controls.DarkTreeView();
            splitContainer1 = new SplitContainer();
            darkSectionPanel1 = new DarkUI.Controls.DarkSectionPanel();
            propertriesGrid = new PropertyGridEx();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            darkSectionPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // updateTimer
            // 
            updateTimer.Interval = 1000;
            updateTimer.Tick += updateTimer_Tick;
            // 
            // widgetView
            // 
            widgetView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            widgetView.Location = new Point(0, 0);
            widgetView.MaxDragChange = 50;
            widgetView.Name = "widgetView";
            widgetView.ShowIcons = true;
            widgetView.Size = new Size(463, 537);
            widgetView.TabIndex = 0;
            widgetView.Text = "darkTreeView1";
            widgetView.SelectedNodesChanged += widgetView_SelectedNodesChanged;
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.Location = new Point(0, 25);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(widgetView);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(darkSectionPanel1);
            splitContainer1.Size = new Size(924, 537);
            splitContainer1.SplitterDistance = 463;
            splitContainer1.TabIndex = 3;
            // 
            // darkSectionPanel1
            // 
            darkSectionPanel1.Controls.Add(propertriesGrid);
            darkSectionPanel1.Dock = DockStyle.Fill;
            darkSectionPanel1.Location = new Point(0, 0);
            darkSectionPanel1.Name = "darkSectionPanel1";
            darkSectionPanel1.SectionHeader = "成员属性";
            darkSectionPanel1.Size = new Size(457, 537);
            darkSectionPanel1.TabIndex = 0;
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
            propertriesGrid.Location = new Point(1, 25);
            propertriesGrid.Name = "propertriesGrid";
            propertriesGrid.SelectedItemWithFocusBackColor = Color.FromArgb(69, 73, 74);
            propertriesGrid.SelectedItemWithFocusForeColor = Color.White;
            propertriesGrid.Size = new Size(455, 511);
            propertriesGrid.TabIndex = 0;
            propertriesGrid.ViewBackColor = Color.FromArgb(60, 63, 65);
            propertriesGrid.ViewBorderColor = Color.FromArgb(51, 51, 51);
            propertriesGrid.ViewForeColor = Color.Gainsboro;
            // 
            // WorldWidgetWindow
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainer1);
            DefaultDockArea = DarkUI.Docking.DarkDockArea.Document;
            DockText = "界面编辑器-玩家呈现";
            Name = "WorldWidgetWindow";
            Size = new Size(924, 565);
            Load += WorldWidgetWindow_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            darkSectionPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Timer updateTimer;
        private DarkUI.Controls.DarkTreeView widgetView;
        private SplitContainer splitContainer1;
        private PropertyGridEx propertriesGrid;
        private DarkUI.Controls.DarkSectionPanel darkSectionPanel1;
    }
}