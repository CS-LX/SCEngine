namespace SCEngine;

public static class Program {
    public static Thread SCThread;
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main() {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        SCThread = new Thread(() => Game.Program.EntryPoint());
        SCThread.Start();
        Application.Run(new MainForm());
    }
}