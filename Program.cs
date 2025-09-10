using Avalonia;
using System;

namespace ProKS1
{
    internal static class Program
    {
        [STAThread]
        public static void Main(string[] args) =>
            BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);

        public static AppBuilder BuildAvaloniaApp() =>
            AppBuilder.Configure<AppRoot>()  
                      .UsePlatformDetect()
                      .LogToTrace();
    }
}
