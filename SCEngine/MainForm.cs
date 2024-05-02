using System.Reflection;
using DarkUI;
using DarkUI.Controls;
using DarkUI.Docking;
using DarkUI.Forms;
namespace SCEngine;

public partial class MainForm : DarkForm {
    public List<DarkToolWindow> ToolWindows = new();

    public static readonly Dictionary<Type, string> WindowNames = new Dictionary<Type, string>() {
        { typeof(WorldEnititesWindow), "世界实体" },
        { typeof(WorldSubsystemsWindow), "世界子系统" },
        { typeof(StaticClassesWindow), "静态类" },
        { typeof(WorldWidgetWindow), "界面编辑器-玩家呈现" }
    };



    public MainForm() {
        InitializeComponent();
        Application.AddMessageFilter(WorkingPanel.DockContentDragFilter);
        Application.AddMessageFilter(WorkingPanel.DockResizeFilter);
    }

    private void WorkingPanel_Load(object sender, EventArgs e) {
        var entitiesWindow = new WorldEnititesWindow();
        var subsystemsWindow = new WorldSubsystemsWindow();
        var staticClassesWindow = new StaticClassesWindow();
        var widgetWindow = new WorldWidgetWindow();
        ToolWindows.Add(entitiesWindow);
        ToolWindows.Add(subsystemsWindow);
        ToolWindows.Add(staticClassesWindow);
        ToolWindows.Add(widgetWindow);
        WorkingPanel.AddContent(entitiesWindow);
        WorkingPanel.AddContent(subsystemsWindow);
        WorkingPanel.AddContent(staticClassesWindow);
        WorkingPanel.AddContent(widgetWindow);

        Type[] windows = GetDarkToolWindowTypes().ToArray();
        ToolStripMenuItem[] windowItems = windows.
            Select(x => new ToolStripMenuItem { Tag = x, Text = (WindowNames.ContainsKey(x) ? WindowNames[x] : x.Name), Name = "OpenWindowItem" }
            ).ToArray();
        添加ToolStripMenuItem.DropDownItems.AddRange(windowItems);
        添加ToolStripMenuItem.DropDownItemClicked += 添加ToolStripMenuItem_DropDownItemClicked;
    }

    private void 添加ToolStripMenuItem_DropDownItemClicked(object? sender, ToolStripItemClickedEventArgs e) {
        switch (e.ClickedItem?.Name) {
            case "OpenWindowItem":
                WorkingPanel.AddContent((DarkDockContent)Activator.CreateInstance(e.ClickedItem?.Tag as Type));
                break;
        }
    }

    private void MainForm_FormClosed(object sender, FormClosedEventArgs e) {
    }

    private void 退出ToolStripMenuItem_Click(object sender, EventArgs e) {
        Application.Exit();
    }

    public static IEnumerable<Type> GetDarkToolWindowTypes() {
        // 获取当前程序集
        Assembly assembly = Assembly.GetExecutingAssembly();

        // 获取所有继承自DarkToolWindow的类型
        IEnumerable<Type> darkToolWindowTypes = assembly.GetTypes()
            .Where(t => t.IsSubclassOf(typeof(DarkToolWindow)));

        // 筛选出可以被Activator.CreateInstance创建的类型
        IEnumerable<Type> creatableTypes = darkToolWindowTypes
            .Where(UIUtils.CanInstantiate);

        return creatableTypes;
    }

    private void darkMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {

    }
}