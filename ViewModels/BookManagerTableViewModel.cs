using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProKS1.Models;
using ProKS1.Services;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace ProKS1.ViewModels
{

    public partial class BookManagerTableViewModel : ViewModelBase
    {
        private readonly BookService _svc = new();

        public string BooksPath => System.IO.Path.Combine(AppContext.BaseDirectory, "books.json");

        public ObservableCollection<Book> Books { get; } = new();
        public ObservableCollection<Book> VisibleBooks { get; } = new();

        [ObservableProperty] private string quickFilter = string.Empty;
        [ObservableProperty] private Book? selectedBook;


        [ObservableProperty] private string newTitle = string.Empty;
        [ObservableProperty] private string newAuthor = string.Empty;
        [ObservableProperty] private string newGenre = string.Empty;
        [ObservableProperty] private string newIsbn = string.Empty;
        [ObservableProperty] private string newYear = string.Empty;  
        [ObservableProperty] private string newCopies = "1";
        [ObservableProperty] private string newError = string.Empty;

        [ObservableProperty] private string saveInfo = string.Empty;

        public BookManagerTableViewModel() => Load();

        [RelayCommand] private void Refresh() => Load();

        [RelayCommand]
        private void ApplyQuickFilter()
        {
            var n = (QuickFilter ?? "").Trim();
            var q = string.IsNullOrWhiteSpace(n)
                ? Books
                : Books.Where(b =>
                      (b.Title ?? "").Contains(n, StringComparison.OrdinalIgnoreCase) ||
                      (b.Author ?? "").Contains(n, StringComparison.OrdinalIgnoreCase));

            VisibleBooks.Clear();
            foreach (var b in q) VisibleBooks.Add(Clone(b));
        }

        [RelayCommand]
        private void ClearQuickFilter()
        {
            QuickFilter = string.Empty;
            RebindVisibleFromBooks();
        }

        [RelayCommand]
        private void AddNew()
        {
            NewError = string.Empty;
            var title = (NewTitle ?? "").Trim();
            if (string.IsNullOrWhiteSpace(title)) { NewError = "Tytuł jest wymagany."; return; }

            if (!int.TryParse(NewYear ?? "", out var year)) year = 0;
            if (!int.TryParse(NewCopies ?? "1", out var copies)) copies = 1;
            if (copies <= 0) copies = 1;

            var added = _svc.Add(new Book
            {
                Title = title,
                Author = (NewAuthor ?? "").Trim(),
                Genre = (NewGenre ?? "").Trim(),
                Isbn = (NewIsbn ?? "").Trim(),
                Year = year,
                CopiesTotal = copies
            });

            NewTitle = NewAuthor = NewGenre = NewIsbn = "";
            NewYear = "";
            NewCopies = "1";

            Load();
            SaveInfo = $"Dodano: {added.Title} (ID {added.Id})";
        }

        [RelayCommand]
        private void SaveAll()
        {
            foreach (var edited in VisibleBooks)
            {
                if (edited.CopiesTotal <= 0) edited.CopiesTotal = 1;
                _svc.Update(edited);
            }
            Load();
            SaveInfo = $"Zapisano {VisibleBooks.Count} pozycji.";
        }

        [RelayCommand]
        private void DeleteSelected()
        {
            if (SelectedBook is null)
            {
                SaveInfo = "Najpierw wybierz książkę do usunięcia.";
                return;
            }

            var id = SelectedBook.Id;
            var title = SelectedBook.Title ?? "";

            var ok = _svc.Remove(id);
            if (ok)
            {
                Load();
                SaveInfo = $"Usunięto: {title} (ID {id}).";
            }
            else
            {
                SaveInfo = $"Nie udało się usunąć ID {id}.";
            }
        }

        private void Load()
        {
            var list = _svc.GetAll().OrderBy(b => b.Title).ToList();

            Books.Clear();
            foreach (var b in list) Books.Add(Clone(b));

            RebindVisibleFromBooks();
            SaveInfo = "";
        }

        private void RebindVisibleFromBooks()
        {
            VisibleBooks.Clear();
            foreach (var b in Books) VisibleBooks.Add(Clone(b));
        }

        private static Book Clone(Book b) => new()
        {
            Id = b.Id,
            Title = b.Title,
            Author = b.Author,
            Genre = b.Genre,
            Year = b.Year,
            Isbn = b.Isbn,
            CopiesTotal = b.CopiesTotal
        };
    }
}
