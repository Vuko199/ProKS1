
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using ProKS1.Views;
using ProKS1.ViewModels;

namespace ProKS1
{
    public partial class AppRoot : Application
    {
        public override void Initialize() => AvaloniaXamlLoader.Load(this);

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                var win = new MainWindow();
                var vm = new MainWindowViewModel { HostWindow = win };
                win.DataContext = vm;
                desktop.MainWindow = win;
            }
            base.OnFrameworkInitializationCompleted();
        }
    }
}
