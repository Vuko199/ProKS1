
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProKS1.Models;
using ProKS1.Services;
using ProKS1.Views;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace ProKS1.ViewModels
{
    public partial class BookSelectionViewModel : ViewModelBase
    {
        private readonly Window _host;
        public ObservableCollection<Book> Books { get; }

        [ObservableProperty] private Book? selectedBook;

        public BookSelectionViewModel(Window host)
        {
            _host = host;
            var defs = new BookService().GetAll();
            Books = new(defs);
        }

        [RelayCommand]
        private async Task ConfirmSelection()
        {
            if (SelectedBook == null) return;
            var entry = new LoanEntryWindow();
            entry.DataContext = new LoanEntryViewModel(SelectedBook, entry);
            await entry.ShowDialog(_host);
            _host.Close();
        }
    }
}
