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
        darkMenuStrip1.SuspendLayout();
        SuspendLayout();
        // 
        // WorkingPanel
        // 
        WorkingPanel.BackColor = Color.FromArgb(60, 63, 65);
        WorkingPanel.Dock = DockStyle.Fill;
        WorkingPanel.Location = new Point(0, 28);
        WorkingPanel.Name = "WorkingPanel";
        WorkingPanel.Size = new Size(1241, 744);
        WorkingPanel.TabIndex = 0;
        WorkingPanel.Load += WorkingPanel_Load;
        // 
        // darkMenuStrip1
        // 
        darkMenuStrip1.BackColor = Color.FromArgb(60, 63, 65);
        darkMenuStrip1.ForeColor = Color.FromArgb(220, 220, 220);
        darkMenuStrip1.ImageScalingSize = new Size(20, 20);
        darkMenuStrip1.Items.AddRange(new ToolStripItem[] { 游戏ToolStripMenuItem, 视图ToolStripMenuItem });
        darkMenuStrip1.Location = new Point(0, 0);
        darkMenuStrip1.Name = "darkMenuStrip1";
        darkMenuStrip1.Padding = new Padding(3, 2, 0, 2);
        darkMenuStrip1.Size = new Size(1241, 28);
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
        添加ToolStripMenuItem.Size = new Size(224, 26);
        添加ToolStripMenuItem.Text = "添加...";
        // 
        // toolStripSeparator1
        // 
        toolStripSeparator1.BackColor = Color.FromArgb(60, 63, 65);
        toolStripSeparator1.ForeColor = Color.FromArgb(220, 220, 220);
        toolStripSeparator1.Margin = new Padding(0, 0, 0, 1);
        toolStripSeparator1.Name = "toolStripSeparator1";
        toolStripSeparator1.Size = new Size(221, 6);
        // 
        // closeAllWindowMenuItem
        // 
        closeAllWindowMenuItem.BackColor = Color.FromArgb(60, 63, 65);
        closeAllWindowMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
        closeAllWindowMenuItem.Name = "closeAllWindowMenuItem";
        closeAllWindowMenuItem.Size = new Size(224, 26);
        closeAllWindowMenuItem.Text = "关闭所有窗口";
        closeAllWindowMenuItem.Click += closeAllWindowMenuItem_Click;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(9F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1241, 772);
        Controls.Add(WorkingPanel);
        Controls.Add(darkMenuStrip1);
        MainMenuStrip = darkMenuStrip1;
        Name = "MainForm";
        Text = "SCEngine";
        FormClosed += MainForm_FormClosed;
        darkMenuStrip1.ResumeLayout(false);
        darkMenuStrip1.PerformLayout();
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
}