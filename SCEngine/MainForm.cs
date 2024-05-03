using System.Diagnostics;
using System.Reflection;
using DarkUI;
using DarkUI.Controls;
using DarkUI.Docking;
using DarkUI.Forms;
namespace SCEngine;

public partial class MainForm : DarkForm {

    #region 字段
    public List<DarkToolWindow> ToolWindows = new();
    public static readonly Dictionary<Type, string> WindowNames = new Dictionary<Type, string>() {
        { typeof(WorldEnititesWindow), "世界实体" },
        { typeof(WorldSubsystemsWindow), "世界子系统" },
        { typeof(StaticClassesWindow), "静态类" },
        { typeof(WorldWidgetWindow), "界面编辑器-玩家呈现" }
    };

    private static IntPtr gameHandle;
    public static IntPtr GameHandle {
        get {
            if (gameHandle == IntPtr.Zero && Engine.Window.m_gameWindow != null) {
                gameHandle = (IntPtr)WindowMethodUtils.GetParentS(Engine.Window.m_gameWindow.WindowInfo.Handle);
            }
            return gameHandle;
        }
    }
    private static IntPtr engineHandle;
    public static IntPtr EngineHandle {
        get {
            if (engineHandle == IntPtr.Zero) {
                engineHandle = (IntPtr)WindowHandlerUtils.GetWindowsHandle(Process.GetCurrentProcess());
            }
            return engineHandle;
        }
    }
    public IntPtr GammingPanelHandle => GammingPanel.Handle;

    #endregion

    #region 方法
    public MainForm() {
        InitializeComponent();
        Application.AddMessageFilter(WorkingPanel.DockContentDragFilter);
        Application.AddMessageFilter(WorkingPanel.DockResizeFilter);
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
    #endregion

    #region UI事件
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

        //设置布局
        while (GameHandle == IntPtr.Zero) {
        }
        WindowHandlerUtils.InsertWindow(GameHandle, GammingPanelHandle);
    }

    private void 添加ToolStripMenuItem_DropDownItemClicked(object? sender, ToolStripItemClickedEventArgs e) {
        switch (e.ClickedItem?.Name) {
            case "OpenWindowItem":
                DarkToolWindow newWindow = (DarkToolWindow)Activator.CreateInstance(e.ClickedItem?.Tag as Type);
                WorkingPanel.AddContent(newWindow);
                ToolWindows.Add(newWindow);
                break;
        }
    }

    private void MainForm_FormClosed(object sender, FormClosedEventArgs e) {
    }

    private void 退出ToolStripMenuItem_Click(object sender, EventArgs e) {
        Application.Exit();
    }

    private void darkMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {

    }

    private void closeAllWindowMenuItem_Click(object sender, EventArgs e) {
        ToolWindows.ForEach(WorkingPanel.RemoveContent);
        ToolWindows.Clear();
    }

    private void GammingPanel_SizeChanged(object sender, EventArgs e) {
        WindowHandlerUtils.SetChildWindowPos(GameHandle, GammingPanelHandle);
    }

    private void 左右分居ToolStripMenuItem_Click(object sender, EventArgs e) {
        workGameSplitContainer.Orientation = Orientation.Vertical;
    }

    private void 上下分居ToolStripMenuItem_Click(object sender, EventArgs e) {
        workGameSplitContainer.Orientation = Orientation.Horizontal;
    }
    #endregion
}