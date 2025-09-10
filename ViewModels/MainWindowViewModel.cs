using Avalonia.Controls;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;

namespace ProKS1.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        public Window? HostWindow { get; set; }

        [RelayCommand]
        private async Task OpenBookSelection()
        {
            var w = new ProKS1.Views.BookSelectionWindow();
            if (HostWindow != null) await w.ShowDialog(HostWindow);
        }

        [RelayCommand]
        private async Task OpenBookManager()
        {
            var w = new ProKS1.Views.BookManagerWindow();
            if (HostWindow != null) await w.ShowDialog(HostWindow);
        }

        [RelayCommand]
        private async Task OpenGlobalTable()
        {
            var w = new ProKS1.Views.GlobalTableWindow();
            if (HostWindow != null) await w.ShowDialog(HostWindow);
        }
    }
}
