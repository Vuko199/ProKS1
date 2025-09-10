
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ProKS1.Views
{
    public partial class LoanEntryWindow : Window
    {
        public LoanEntryWindow(){ InitializeComponent(); }
        private void InitializeComponent() => AvaloniaXamlLoader.Load(this);
    }
}
