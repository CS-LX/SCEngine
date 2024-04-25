using DarkUI.Controls;
using href.Controls.PropGridEx;

namespace SCEngine {
    partial class StaticClassesWindow {
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
            staticClassesView = new DarkListView();
            splitContainer1 = new SplitContainer();
            searchButton = new DarkButton();
            searchKeyBox = new DarkTextBox();
            darkSectionPanel1 = new DarkSectionPanel();
            propertriesGrid = new PropertyGridEx();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            darkSectionPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // staticClassesView
            // 
            staticClassesView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            staticClassesView.Location = new Point(0, 36);
            staticClassesView.MaxDragChange = 50;
            staticClassesView.Name = "staticClassesView";
            staticClassesView.ShowIcons = true;
            staticClassesView.Size = new Size(463, 504);
            staticClassesView.TabIndex = 0;
            staticClassesView.Text = "darkTreeView1";
            staticClassesView.SelectedIndicesChanged += staticClassesView_SelectedIndicesChanged;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 25);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(searchButton);
            splitContainer1.Panel1.Controls.Add(searchKeyBox);
            splitContainer1.Panel1.Controls.Add(staticClassesView);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(darkSectionPanel1);
            splitContainer1.Size = new Size(924, 540);
            splitContainer1.SplitterDistance = 463;
            splitContainer1.TabIndex = 3;
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
            // darkSectionPanel1
            // 
            darkSectionPanel1.Controls.Add(propertriesGrid);
            darkSectionPanel1.Dock = DockStyle.Fill;
            darkSectionPanel1.Location = new Point(0, 0);
            darkSectionPanel1.Name = "darkSectionPanel1";
            darkSectionPanel1.SectionHeader = "成员属性";
            darkSectionPanel1.Size = new Size(457, 540);
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
            propertriesGrid.EnableXml = false;
            propertriesGrid.HelpBackColor = Color.FromArgb(60, 63, 65);
            propertriesGrid.HelpBorderColor = Color.FromArgb(51, 51, 51);
            propertriesGrid.HelpForeColor = Color.Gainsboro;
            propertriesGrid.LineColor = Color.FromArgb(51, 51, 51);
            propertriesGrid.Location = new Point(1, 25);
            propertriesGrid.Name = "propertriesGrid";
            propertriesGrid.SelectedItemWithFocusBackColor = Color.FromArgb(69, 73, 74);
            propertriesGrid.SelectedItemWithFocusForeColor = Color.White;
            propertriesGrid.Size = new Size(455, 514);
            propertriesGrid.TabIndex = 0;
            propertriesGrid.ViewBackColor = Color.FromArgb(60, 63, 65);
            propertriesGrid.ViewBorderColor = Color.FromArgb(51, 51, 51);
            propertriesGrid.ViewForeColor = Color.Gainsboro;
            // 
            // StaticClassesWindow
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainer1);
            DefaultDockArea = DarkUI.Docking.DarkDockArea.Document;
            DockText = "静态类";
            Name = "StaticClassesWindow";
            Size = new Size(924, 565);
            Load += WorldSubsystemsWindow_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            darkSectionPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private DarkListView staticClassesView;
        private SplitContainer splitContainer1;
        private PropertyGridEx propertriesGrid;
        private DarkUI.Controls.DarkSectionPanel darkSectionPanel1;
        private DarkUI.Controls.DarkTextBox searchKeyBox;
        private DarkUI.Controls.DarkButton searchButton;
    }
}