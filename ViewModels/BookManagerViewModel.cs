
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProKS1.Models;
using ProKS1.Services;
using System.Collections.ObjectModel;
using System.Linq;

namespace ProKS1.ViewModels
{
    public partial class BookManagerViewModel : ViewModelBase
    {
        private readonly BookService _svc = new();
        public ObservableCollection<Book> Books { get; } = new();

        [ObservableProperty] private Book? selectedBook;

        [ObservableProperty] private string title = string.Empty;
        [ObservableProperty] private string author = string.Empty;
        [ObservableProperty] private string isbn = string.Empty;
        [ObservableProperty] private int year;
        [ObservableProperty] private string genre = string.Empty;
        [ObservableProperty] private int copiesTotal = 1;

        public BookManagerViewModel()
        {
            Load();
        }

        private void Load()
        {
            Books.Clear();
            foreach (var p in _svc.GetAll().OrderBy(p => p.Title)) Books.Add(p);
        }

        [RelayCommand]
        private void AddBook()
        {
            var t = (Title ?? string.Empty).Trim();
            if (string.IsNullOrWhiteSpace(t)) return;
            _svc.Add(new Book{
                Title=t,
                Author=Author?.Trim() ?? "",
                Isbn=Isbn?.Trim() ?? "",
                Year=Year,
                Genre=Genre?.Trim() ?? "",
                CopiesTotal=CopiesTotal<=0?1:CopiesTotal
            });
            Title=Author=Isbn=Genre=string.Empty; Year=0; CopiesTotal=1;
            Load();
        }

        public bool DeleteSelectedInternal()
        {
            if (SelectedBook == null) return false;
            var ok = _svc.Remove(SelectedBook.Id);
            Load();
            return ok;
        }
    }
}
