using DarkUI;
using DarkUI.Docking;
using DarkUI.Forms;
namespace SCEngine;

public partial class MainForm : DarkForm {
    public WorldEnititesWindow GammingForm;

    public MainForm() {
        InitializeComponent();
        GammingForm = new WorldEnititesWindow();
        Application.AddMessageFilter(WorkingPanel.DockContentDragFilter);
        Application.AddMessageFilter(WorkingPanel.DockResizeFilter);
    }

    private void WorkingPanel_Load(object sender, EventArgs e) {
        WorkingPanel.AddContent(GammingForm);
    }

    private void MainForm_FormClosed(object sender, FormClosedEventArgs e) {
    }
}