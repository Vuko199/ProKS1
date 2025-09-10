using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ProKS1.ViewModels;

namespace ProKS1.Views
{
    public partial class BookManagerWindow : Window
    {
        public BookManagerWindow()
        {
            InitializeComponent();
            DataContext = new BookManagerTableViewModel();
        }

        private void InitializeComponent() => AvaloniaXamlLoader.Load(this);
    }
}
