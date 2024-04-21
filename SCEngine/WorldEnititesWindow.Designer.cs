namespace SCEngine {
    partial class WorldEnititesWindow {
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
            entitiesView = new DarkUI.Controls.DarkTreeView();
            updateButton = new DarkUI.Controls.DarkButton();
            autoUpdateChechBox = new DarkUI.Controls.DarkCheckBox();
            SuspendLayout();
            // 
            // updateTimer
            // 
            updateTimer.Interval = 1000;
            updateTimer.Tick += updateTimer_Tick;
            // 
            // entitiesView
            // 
            entitiesView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            entitiesView.Location = new Point(0, 28);
            entitiesView.MaxDragChange = 20;
            entitiesView.Name = "entitiesView";
            entitiesView.ShowIcons = true;
            entitiesView.Size = new Size(797, 392);
            entitiesView.TabIndex = 0;
            entitiesView.Text = "darkTreeView1";
            // 
            // updateButton
            // 
            updateButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            updateButton.Location = new Point(3, 426);
            updateButton.Name = "updateButton";
            updateButton.Padding = new Padding(5);
            updateButton.Size = new Size(697, 32);
            updateButton.TabIndex = 1;
            updateButton.Text = "更新";
            updateButton.Click += updateButton_Click;
            // 
            // autoUpdateChechBox
            // 
            autoUpdateChechBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            autoUpdateChechBox.AutoSize = true;
            autoUpdateChechBox.Location = new Point(706, 426);
            autoUpdateChechBox.Name = "autoUpdateChechBox";
            autoUpdateChechBox.Size = new Size(91, 24);
            autoUpdateChechBox.TabIndex = 2;
            autoUpdateChechBox.Text = "自动刷新";
            autoUpdateChechBox.CheckedChanged += autoUpdateChechBox_CheckedChanged;
            // 
            // WorldEnititesWindow
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(autoUpdateChechBox);
            Controls.Add(updateButton);
            Controls.Add(entitiesView);
            DefaultDockArea = DarkUI.Docking.DarkDockArea.Document;
            DockText = "实体";
            Name = "WorldEnititesWindow";
            Size = new Size(800, 461);
            Load += WorldEnititesWindow_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Timer updateTimer;
        private DarkUI.Controls.DarkTreeView entitiesView;
        private DarkUI.Controls.DarkButton updateButton;
        private DarkUI.Controls.DarkCheckBox autoUpdateChechBox;
    }
}