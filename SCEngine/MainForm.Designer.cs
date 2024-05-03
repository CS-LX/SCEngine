namespace SCEngine;

partial class MainForm {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
        WorkingPanel = new DarkUI.Docking.DarkDockPanel();
        darkMenuStrip1 = new DarkUI.Controls.DarkMenuStrip();
        游戏ToolStripMenuItem = new ToolStripMenuItem();
        退出ToolStripMenuItem = new ToolStripMenuItem();
        视图ToolStripMenuItem = new ToolStripMenuItem();
        添加ToolStripMenuItem = new ToolStripMenuItem();
        toolStripSeparator1 = new ToolStripSeparator();
        closeAllWindowMenuItem = new ToolStripMenuItem();
        窗口ToolStripMenuItem = new ToolStripMenuItem();
        布局ToolStripMenuItem = new ToolStripMenuItem();
        左右分居ToolStripMenuItem = new ToolStripMenuItem();
        上下分居ToolStripMenuItem = new ToolStripMenuItem();
        workGameSplitContainer = new SplitContainer();
        GammingPanel = new Panel();
        darkMenuStrip1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)workGameSplitContainer).BeginInit();
        workGameSplitContainer.Panel1.SuspendLayout();
        workGameSplitContainer.Panel2.SuspendLayout();
        workGameSplitContainer.SuspendLayout();
        SuspendLayout();
        // 
        // WorkingPanel
        // 
        WorkingPanel.BackColor = Color.FromArgb(60, 63, 65);
        WorkingPanel.Dock = DockStyle.Fill;
        WorkingPanel.Location = new Point(0, 0);
        WorkingPanel.Name = "WorkingPanel";
        WorkingPanel.Size = new Size(573, 744);
        WorkingPanel.TabIndex = 0;
        WorkingPanel.Load += WorkingPanel_Load;
        // 
        // darkMenuStrip1
        // 
        darkMenuStrip1.BackColor = Color.FromArgb(60, 63, 65);
        darkMenuStrip1.ForeColor = Color.FromArgb(220, 220, 220);
        darkMenuStrip1.ImageScalingSize = new Size(20, 20);
        darkMenuStrip1.Items.AddRange(new ToolStripItem[] { 游戏ToolStripMenuItem, 视图ToolStripMenuItem, 窗口ToolStripMenuItem });
        darkMenuStrip1.Location = new Point(0, 0);
        darkMenuStrip1.Name = "darkMenuStrip1";
        darkMenuStrip1.Padding = new Padding(3, 2, 0, 2);
        darkMenuStrip1.Size = new Size(1079, 28);
        darkMenuStrip1.TabIndex = 1;
        darkMenuStrip1.Text = "darkMenuStrip1";
        darkMenuStrip1.ItemClicked += darkMenuStrip1_ItemClicked;
        // 
        // 游戏ToolStripMenuItem
        // 
        游戏ToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
        游戏ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 退出ToolStripMenuItem });
        游戏ToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
        游戏ToolStripMenuItem.Name = "游戏ToolStripMenuItem";
        游戏ToolStripMenuItem.Size = new Size(53, 24);
        游戏ToolStripMenuItem.Text = "程序";
        // 
        // 退出ToolStripMenuItem
        // 
        退出ToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
        退出ToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
        退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
        退出ToolStripMenuItem.Size = new Size(122, 26);
        退出ToolStripMenuItem.Text = "退出";
        退出ToolStripMenuItem.Click += 退出ToolStripMenuItem_Click;
        // 
        // 视图ToolStripMenuItem
        // 
        视图ToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
        视图ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 添加ToolStripMenuItem, toolStripSeparator1, closeAllWindowMenuItem });
        视图ToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
        视图ToolStripMenuItem.Name = "视图ToolStripMenuItem";
        视图ToolStripMenuItem.Size = new Size(53, 24);
        视图ToolStripMenuItem.Text = "视图";
        // 
        // 添加ToolStripMenuItem
        // 
        添加ToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
        添加ToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
        添加ToolStripMenuItem.Name = "添加ToolStripMenuItem";
        添加ToolStripMenuItem.Size = new Size(182, 26);
        添加ToolStripMenuItem.Text = "添加...";
        // 
        // toolStripSeparator1
        // 
        toolStripSeparator1.BackColor = Color.FromArgb(60, 63, 65);
        toolStripSeparator1.ForeColor = Color.FromArgb(220, 220, 220);
        toolStripSeparator1.Margin = new Padding(0, 0, 0, 1);
        toolStripSeparator1.Name = "toolStripSeparator1";
        toolStripSeparator1.Size = new Size(179, 6);
        // 
        // closeAllWindowMenuItem
        // 
        closeAllWindowMenuItem.BackColor = Color.FromArgb(60, 63, 65);
        closeAllWindowMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
        closeAllWindowMenuItem.Name = "closeAllWindowMenuItem";
        closeAllWindowMenuItem.Size = new Size(182, 26);
        closeAllWindowMenuItem.Text = "关闭所有窗口";
        closeAllWindowMenuItem.Click += closeAllWindowMenuItem_Click;
        // 
        // 窗口ToolStripMenuItem
        // 
        窗口ToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
        窗口ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 布局ToolStripMenuItem });
        窗口ToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
        窗口ToolStripMenuItem.Name = "窗口ToolStripMenuItem";
        窗口ToolStripMenuItem.Size = new Size(53, 24);
        窗口ToolStripMenuItem.Text = "窗口";
        // 
        // 布局ToolStripMenuItem
        // 
        布局ToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
        布局ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 左右分居ToolStripMenuItem, 上下分居ToolStripMenuItem });
        布局ToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
        布局ToolStripMenuItem.Name = "布局ToolStripMenuItem";
        布局ToolStripMenuItem.Size = new Size(224, 26);
        布局ToolStripMenuItem.Text = "布局";
        // 
        // 左右分居ToolStripMenuItem
        // 
        左右分居ToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
        左右分居ToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
        左右分居ToolStripMenuItem.Name = "左右分居ToolStripMenuItem";
        左右分居ToolStripMenuItem.Size = new Size(224, 26);
        左右分居ToolStripMenuItem.Text = "水平分局";
        左右分居ToolStripMenuItem.Click += 左右分居ToolStripMenuItem_Click;
        // 
        // 上下分居ToolStripMenuItem
        // 
        上下分居ToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
        上下分居ToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
        上下分居ToolStripMenuItem.Name = "上下分居ToolStripMenuItem";
        上下分居ToolStripMenuItem.Size = new Size(224, 26);
        上下分居ToolStripMenuItem.Text = "垂直分居";
        上下分居ToolStripMenuItem.Click += 上下分居ToolStripMenuItem_Click;
        // 
        // workGameSplitContainer
        // 
        workGameSplitContainer.Dock = DockStyle.Fill;
        workGameSplitContainer.Location = new Point(0, 28);
        workGameSplitContainer.Name = "workGameSplitContainer";
        // 
        // workGameSplitContainer.Panel1
        // 
        workGameSplitContainer.Panel1.Controls.Add(WorkingPanel);
        // 
        // workGameSplitContainer.Panel2
        // 
        workGameSplitContainer.Panel2.Controls.Add(GammingPanel);
        workGameSplitContainer.Size = new Size(1079, 744);
        workGameSplitContainer.SplitterDistance = 573;
        workGameSplitContainer.TabIndex = 2;
        // 
        // GammingPanel
        // 
        GammingPanel.Dock = DockStyle.Fill;
        GammingPanel.Location = new Point(0, 0);
        GammingPanel.Name = "GammingPanel";
        GammingPanel.Size = new Size(502, 744);
        GammingPanel.TabIndex = 0;
        GammingPanel.SizeChanged += GammingPanel_SizeChanged;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(9F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1079, 772);
        Controls.Add(workGameSplitContainer);
        Controls.Add(darkMenuStrip1);
        MainMenuStrip = darkMenuStrip1;
        Name = "MainForm";
        Text = "SCEngine";
        FormClosed += MainForm_FormClosed;
        darkMenuStrip1.ResumeLayout(false);
        darkMenuStrip1.PerformLayout();
        workGameSplitContainer.Panel1.ResumeLayout(false);
        workGameSplitContainer.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)workGameSplitContainer).EndInit();
        workGameSplitContainer.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private DarkUI.Docking.DarkDockPanel WorkingPanel;
    private DarkUI.Controls.DarkMenuStrip darkMenuStrip1;
    private ToolStripMenuItem 游戏ToolStripMenuItem;
    private ToolStripMenuItem 视图ToolStripMenuItem;
    private ToolStripMenuItem 添加ToolStripMenuItem;
    private ToolStripMenuItem 退出ToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripMenuItem closeAllWindowMenuItem;
    private ToolStripMenuItem 窗口ToolStripMenuItem;
    private ToolStripMenuItem 布局ToolStripMenuItem;
    private ToolStripMenuItem 左右分居ToolStripMenuItem;
    private SplitContainer workGameSplitContainer;
    private Panel GammingPanel;
    private ToolStripMenuItem 上下分居ToolStripMenuItem;
}