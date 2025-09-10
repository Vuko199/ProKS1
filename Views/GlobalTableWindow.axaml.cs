using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ProKS1.ViewModels;

namespace ProKS1.Views
{
    public partial class GlobalTableWindow : Window
    {
        public GlobalTableWindow()
        {
            InitializeComponent();
            DataContext = new GlobalTableViewModel(); 
        }

        private void InitializeComponent() => AvaloniaXamlLoader.Load(this);
    }
}
