using href.Controls.PropGridEx;

namespace SCEngine {
    partial class WorldSubsystemsWindow {
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
            subsystemsView = new DarkUI.Controls.DarkTreeView();
            updateButton = new DarkUI.Controls.DarkButton();
            autoUpdateChechBox = new DarkUI.Controls.DarkCheckBox();
            splitContainer1 = new SplitContainer();
            darkSectionPanel1 = new DarkUI.Controls.DarkSectionPanel();
            propertriesGrid = new PropertyGridSC();
            searchKeyBox = new DarkUI.Controls.DarkTextBox();
            searchButton = new DarkUI.Controls.DarkButton();
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
            // subsystemsView
            // 
            subsystemsView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            subsystemsView.Location = new Point(0, 36);
            subsystemsView.MaxDragChange = 50;
            subsystemsView.Name = "subsystemsView";
            subsystemsView.ShowIcons = true;
            subsystemsView.Size = new Size(463, 463);
            subsystemsView.TabIndex = 0;
            subsystemsView.Text = "darkTreeView1";
            subsystemsView.SelectedNodesChanged += entitiesView_SelectedNodesChanged;
            // 
            // updateButton
            // 
            updateButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            updateButton.Location = new Point(3, 530);
            updateButton.Name = "updateButton";
            updateButton.Padding = new Padding(5);
            updateButton.Size = new Size(821, 32);
            updateButton.TabIndex = 1;
            updateButton.Text = "更新";
            updateButton.Click += updateButton_Click;
            // 
            // autoUpdateChechBox
            // 
            autoUpdateChechBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            autoUpdateChechBox.AutoSize = true;
            autoUpdateChechBox.Checked = true;
            autoUpdateChechBox.CheckState = CheckState.Checked;
            autoUpdateChechBox.Location = new Point(830, 530);
            autoUpdateChechBox.Name = "autoUpdateChechBox";
            autoUpdateChechBox.Size = new Size(91, 24);
            autoUpdateChechBox.TabIndex = 2;
            autoUpdateChechBox.Text = "自动刷新";
            autoUpdateChechBox.CheckedChanged += autoUpdateChechBox_CheckedChanged;
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.Location = new Point(0, 25);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(searchButton);
            splitContainer1.Panel1.Controls.Add(searchKeyBox);
            splitContainer1.Panel1.Controls.Add(subsystemsView);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(darkSectionPanel1);
            splitContainer1.Size = new Size(924, 499);
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
            darkSectionPanel1.Size = new Size(457, 499);
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
            propertriesGrid.HelpBackColor = Color.FromArgb(60, 63, 65);
            propertriesGrid.HelpBorderColor = Color.FromArgb(51, 51, 51);
            propertriesGrid.HelpForeColor = Color.Gainsboro;
            propertriesGrid.LineColor = Color.FromArgb(51, 51, 51);
            propertriesGrid.Location = new Point(1, 25);
            propertriesGrid.Name = "propertriesGrid";
            propertriesGrid.SelectedItemWithFocusBackColor = Color.FromArgb(69, 73, 74);
            propertriesGrid.SelectedItemWithFocusForeColor = Color.White;
            propertriesGrid.Size = new Size(455, 473);
            propertriesGrid.TabIndex = 0;
            propertriesGrid.ViewBackColor = Color.FromArgb(60, 63, 65);
            propertriesGrid.ViewBorderColor = Color.FromArgb(51, 51, 51);
            propertriesGrid.ViewForeColor = Color.Gainsboro;
            // 
            // searchKeyBox
            // 
            searchKeyBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            searchKeyBox.BackColor = Color.FromArgb(69, 73, 74);
            searchKeyBox.BorderStyle = BorderStyle.FixedSingle;
            searchKeyBox.ForeColor = Color.FromArgb(220, 220, 220);
            searchKeyBox.Location = new Point(3, 3);
            searchKeyBox.Name = "searchKeyBox";
            searchKeyBox.Size = new Size(382, 27);
            searchKeyBox.TabIndex = 1;
            // 
            // searchButton
            // 
            searchButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            searchButton.Location = new Point(391, 3);
            searchButton.Name = "searchButton";
            searchButton.Padding = new Padding(5);
            searchButton.Size = new Size(69, 27);
            searchButton.TabIndex = 2;
            searchButton.Text = "搜索";
            searchButton.Click += searchButton_Click;
            // 
            // WorldSubsystemsWindow
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainer1);
            Controls.Add(autoUpdateChechBox);
            Controls.Add(updateButton);
            DefaultDockArea = DarkUI.Docking.DarkDockArea.Document;
            DockText = "世界子系统";
            Name = "WorldSubsystemsWindow";
            Size = new Size(924, 565);
            Load += WorldSubsystemsWindow_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            darkSectionPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Timer updateTimer;
        private DarkUI.Controls.DarkTreeView subsystemsView;
        private DarkUI.Controls.DarkButton updateButton;
        private DarkUI.Controls.DarkCheckBox autoUpdateChechBox;
        private SplitContainer splitContainer1;
        private PropertyGridSC propertriesGrid;
        private DarkUI.Controls.DarkSectionPanel darkSectionPanel1;
        private DarkUI.Controls.DarkTextBox searchKeyBox;
        private DarkUI.Controls.DarkButton searchButton;
    }
}