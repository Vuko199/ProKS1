
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ProKS1.ViewModels;

namespace ProKS1.Views
{
    public partial class BookSelectionWindow : Window
    {
        public BookSelectionWindow()
        {
            InitializeComponent();
            DataContext = new BookSelectionViewModel(this);
        }
        private void InitializeComponent() => AvaloniaXamlLoader.Load(this);
    }
}
