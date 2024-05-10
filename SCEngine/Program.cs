using System.Reflection;

namespace SCEngine;

public static class Program {
    public static Thread SCThread;
    public static Thread UpdateThread;
    public static bool GameStarted = false;
    public static MainForm MainForm;

    public static Action<Dictionary<string, Assembly>> DllsLoaded = (dic) => { };
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main() {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        //打开SC
        SCThread = new Thread(() => Game.Program.EntryPoint());
        SCThread.Start();
        GameStarted = true;
        //打开更新
        UpdateThread = new Thread(Update);
        UpdateThread.Start();

        MainForm = new MainForm();
        Application.Run(MainForm);
    }

    static void Update() {
        while (GameStarted == true && SCThread.IsAlive) {
        }
        //游戏关闭了就退出
        Application.Exit();
    }
}