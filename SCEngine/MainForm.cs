using System.Diagnostics;
using System.Reflection;
using DarkUI;
using DarkUI.Controls;
using DarkUI.Docking;
using DarkUI.Forms;
namespace SCEngine;

public partial class MainForm : DarkForm {

    #region 字段
    public static readonly Dictionary<Type, string> WindowNames = new Dictionary<Type, string>() {
        { typeof(WorldEnititesWindow), "世界实体" },
        { typeof(WorldSubsystemsWindow), "世界子系统" },
        { typeof(InspectorWindow), "检查器" },
        { typeof(StaticClassesWindow), "静态类" },
        { typeof(WorldWidgetWindow), "界面编辑器-玩家呈现" }
    };

    private static IntPtr gameHandle;
    public static IntPtr GameHandle {
        get {
            if (gameHandle == IntPtr.Zero && Engine.Window.m_gameWindow != null) {
                if (ModsManager.APIVersion.Contains("1.7")) {
                    //如果内置SC分支处于这个更改，窗口会出bug，因为这时版本是1.7但是窗口为发生父级关系改变
                    //                    ID 作者  日期 消息
                    //611329603eb77ae3e1e5951c6de2b825e9bb17f7 把红色赋予黑海_🔴 < heihaixiaonanliang@qq.com > 2024 / 4 / 23 9:55:09 + 00:00    修复问题，修改版本号为1.70A 此分支已修改为1.7，1.6将在另一分支
                    gameHandle = Engine.Window.m_gameWindow.WindowInfo.Handle;
                }
                else {
                    gameHandle = (IntPtr)CPP.GetParentS(Engine.Window.m_gameWindow.WindowInfo.Handle);
                }
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

    public T? FindSubwindow<T>() where T : DarkToolWindow {
        foreach (DarkToolWindow window in WorkingPanel.Content) {
            if (window.GetType() == typeof(T)) {
                return (T?)window;
            }
        }
        return null;
    }

    public DarkToolWindow AddSubwindow(DarkToolWindow window, DarkDockArea dockArea) {
        window.DefaultDockArea = dockArea;
        WorkingPanel.AddContent(window);
        return window;
    }
    #endregion

    #region UI事件
    private void WorkingPanel_Load(object sender, EventArgs e) {
        var entitiesWindow = new WorldEnititesWindow();
        var subsystemsWindow = new WorldSubsystemsWindow();
        var staticClassesWindow = new StaticClassesWindow();
        var widgetWindow = new WorldWidgetWindow();
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
                break;
        }
    }

    private void MainForm_FormClosed(object sender, FormClosedEventArgs e) {
    }

    private void 退出ToolStripMenuItem_Click(object sender, EventArgs e) {
        Application.Exit();
    }
    private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
        if (Engine.Window.m_gameWindow != null) Engine.Window.Close();
    }

    private void darkMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {

    }

    private void closeAllWindowMenuItem_Click(object sender, EventArgs e) {
        List<DarkDockContent> temp = new List<DarkDockContent>(WorkingPanel.Content);
        temp.ForEach(WorkingPanel.RemoveContent);
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

    private void MainForm_Load(object sender, EventArgs e) {
        while (ModsManager.Dlls.Count <= 0) { }
        Program.DllsLoaded.Invoke(ModsManager.Dlls);
    }
    #endregion
}