using DarkUI.Controls;
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
            widgetView = new DarkTreeView();
            splitContainer1 = new SplitContainer();
            splitContainer2 = new SplitContainer();
            darkSectionPanel2 = new DarkSectionPanel();
            toolBox = new DarkTreeView();
            newWidgetButton = new DarkButton();
            enableXmlExportButton = new DarkButton();
            exportXmlButton = new DarkButton();
            removeWidgetButton = new DarkButton();
            darkSectionPanel1 = new DarkSectionPanel();
            propertriesGrid = new PropertyGridEx();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            darkSectionPanel2.SuspendLayout();
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
            widgetView.Location = new Point(3, 0);
            widgetView.MaxDragChange = 50;
            widgetView.Name = "widgetView";
            widgetView.ShowIcons = true;
            widgetView.Size = new Size(415, 496);
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
            splitContainer1.Panel1.Controls.Add(splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(darkSectionPanel1);
            splitContainer1.Size = new Size(924, 537);
            splitContainer1.SplitterDistance = 633;
            splitContainer1.TabIndex = 3;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(darkSectionPanel2);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(newWidgetButton);
            splitContainer2.Panel2.Controls.Add(enableXmlExportButton);
            splitContainer2.Panel2.Controls.Add(exportXmlButton);
            splitContainer2.Panel2.Controls.Add(removeWidgetButton);
            splitContainer2.Panel2.Controls.Add(widgetView);
            splitContainer2.Size = new Size(633, 537);
            splitContainer2.SplitterDistance = 211;
            splitContainer2.TabIndex = 2;
            // 
            // darkSectionPanel2
            // 
            darkSectionPanel2.Controls.Add(toolBox);
            darkSectionPanel2.Dock = DockStyle.Fill;
            darkSectionPanel2.Location = new Point(0, 0);
            darkSectionPanel2.Name = "darkSectionPanel2";
            darkSectionPanel2.SectionHeader = "工具箱";
            darkSectionPanel2.Size = new Size(211, 537);
            darkSectionPanel2.TabIndex = 1;
            // 
            // toolBox
            // 
            toolBox.Dock = DockStyle.Fill;
            toolBox.Location = new Point(1, 25);
            toolBox.MaxDragChange = 20;
            toolBox.Name = "toolBox";
            toolBox.Size = new Size(209, 511);
            toolBox.TabIndex = 0;
            toolBox.DoubleClick += toolBox_DoubleClick;
            // 
            // newWidgetButton
            // 
            newWidgetButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            newWidgetButton.CenterIcon = Properties.Resources.Add;
            newWidgetButton.CenterIconScale = 0.4F;
            newWidgetButton.Location = new Point(345, 502);
            newWidgetButton.Name = "newWidgetButton";
            newWidgetButton.Padding = new Padding(5);
            newWidgetButton.Size = new Size(32, 32);
            newWidgetButton.TabIndex = 4;
            newWidgetButton.Click += newWidgetButton_Click;
            // 
            // enableXmlExportButton
            // 
            enableXmlExportButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            enableXmlExportButton.CenterIcon = Properties.Resources.ChessboxPage;
            enableXmlExportButton.CenterIconScale = 0.3F;
            enableXmlExportButton.Location = new Point(41, 502);
            enableXmlExportButton.Name = "enableXmlExportButton";
            enableXmlExportButton.Padding = new Padding(5);
            enableXmlExportButton.Size = new Size(32, 32);
            enableXmlExportButton.TabIndex = 3;
            enableXmlExportButton.Click += enableXmlExportButton_Click;
            // 
            // exportXmlButton
            // 
            exportXmlButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            exportXmlButton.CenterIcon = Properties.Resources.Export;
            exportXmlButton.CenterIconScale = 0.32F;
            exportXmlButton.Location = new Point(383, 502);
            exportXmlButton.Name = "exportXmlButton";
            exportXmlButton.Padding = new Padding(5);
            exportXmlButton.Size = new Size(32, 32);
            exportXmlButton.TabIndex = 2;
            exportXmlButton.Click += exportXmlButton_Click;
            // 
            // removeWidgetButton
            // 
            removeWidgetButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            removeWidgetButton.CenterIcon = Properties.Resources.Bin;
            removeWidgetButton.CenterIconScale = 0.32F;
            removeWidgetButton.Location = new Point(3, 502);
            removeWidgetButton.Name = "removeWidgetButton";
            removeWidgetButton.Padding = new Padding(5);
            removeWidgetButton.Size = new Size(32, 32);
            removeWidgetButton.TabIndex = 1;
            removeWidgetButton.Click += removeWidgetButton_Click;
            // 
            // darkSectionPanel1
            // 
            darkSectionPanel1.Controls.Add(propertriesGrid);
            darkSectionPanel1.Dock = DockStyle.Fill;
            darkSectionPanel1.Location = new Point(0, 0);
            darkSectionPanel1.Name = "darkSectionPanel1";
            darkSectionPanel1.SectionHeader = "成员属性";
            darkSectionPanel1.Size = new Size(287, 537);
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
            propertriesGrid.Size = new Size(285, 511);
            propertriesGrid.TabIndex = 0;
            propertriesGrid.ViewBackColor = Color.FromArgb(60, 63, 65);
            propertriesGrid.ViewBorderColor = Color.FromArgb(51, 51, 51);
            propertriesGrid.ViewForeColor = Color.Gainsboro;
            propertriesGrid.PropertyValueChanged += propertriesGrid_PropertyValueChanged;
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
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            darkSectionPanel2.ResumeLayout(false);
            darkSectionPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Timer updateTimer;
        private DarkUI.Controls.DarkTreeView widgetView;
        private SplitContainer splitContainer1;
        private PropertyGridEx propertriesGrid;
        private DarkUI.Controls.DarkSectionPanel darkSectionPanel1;
        private DarkButton removeWidgetButton;
        private SplitContainer splitContainer2;
        private DarkTreeView toolBox;
        private DarkSectionPanel darkSectionPanel2;
        private DarkButton exportXmlButton;
        private DarkButton enableXmlExportButton;
        private DarkButton newWidgetButton;
    }
}