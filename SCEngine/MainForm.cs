using DarkUI;
using DarkUI.Docking;
using DarkUI.Forms;
namespace SCEngine;

public partial class MainForm : DarkForm {
    public WorldEnititesWindow EntitiesForm;
    public WorldSubsystemsWindow SubsystemsForm;
    public StaticClassesWindow StaticClassesForm;

    public MainForm() {
        InitializeComponent();
        EntitiesForm = new WorldEnititesWindow();
        SubsystemsForm = new WorldSubsystemsWindow();
        StaticClassesForm = new StaticClassesWindow();
        Application.AddMessageFilter(WorkingPanel.DockContentDragFilter);
        Application.AddMessageFilter(WorkingPanel.DockResizeFilter);
    }

    private void WorkingPanel_Load(object sender, EventArgs e) {
        WorkingPanel.AddContent(EntitiesForm);
        WorkingPanel.AddContent(SubsystemsForm);
        WorkingPanel.AddContent(StaticClassesForm);
    }

    private void MainForm_FormClosed(object sender, FormClosedEventArgs e) {
    }

    private void 退出ToolStripMenuItem_Click(object sender, EventArgs e) {
        Application.Exit();
    }
}