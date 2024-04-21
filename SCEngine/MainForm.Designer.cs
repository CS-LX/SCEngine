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
        SuspendLayout();
        // 
        // WorkingPanel
        // 
        WorkingPanel.BackColor = Color.FromArgb(60, 63, 65);
        WorkingPanel.Dock = DockStyle.Fill;
        WorkingPanel.Location = new Point(0, 0);
        WorkingPanel.Name = "WorkingPanel";
        WorkingPanel.Size = new Size(1040, 479);
        WorkingPanel.TabIndex = 0;
        WorkingPanel.Load += WorkingPanel_Load;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(9F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1040, 479);
        Controls.Add(WorkingPanel);
        Name = "MainForm";
        Text = "SCEngine";
        FormClosed += MainForm_FormClosed;
        ResumeLayout(false);
    }

    #endregion

    private DarkUI.Docking.DarkDockPanel WorkingPanel;
}