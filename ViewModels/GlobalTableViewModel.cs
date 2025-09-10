using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using ProKS1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace ProKS1.ViewModels
{
    public partial class GlobalTableViewModel : ViewModelBase
    {
        public class Row
        {
            public int Id { get; init; }
            public string BookTitle { get; init; } = "";
            public string BookAuthor { get; init; } = "";
            public string BorrowerName { get; init; } = "";
            public string BorrowerPhone { get; init; } = "";
            public string Notes { get; init; } = "";
            public DateTime BorrowedAt { get; init; }
            public DateTime DueAt { get; init; }
            public DateTime? ReturnedAt { get; init; }
            public string BorrowedAtStr => BorrowedAt.ToString("yyyy-MM-dd");
            public string DueAtStr => DueAt.ToString("yyyy-MM-dd");
            public string ReturnedAtStr => ReturnedAt.HasValue ? ReturnedAt.Value.ToString("yyyy-MM-dd") : "";
        }

        // pliki przy exe
        public string LoansPath { get; } = Path.Combine(AppContext.BaseDirectory, "loans.json");
        public string BooksPath { get; } = Path.Combine(AppContext.BaseDirectory, "books.json");

        // dane
        public ObservableCollection<Row> FilteredRows { get; } = new();
        private List<Row> AllRowsInternal = new();

        // licznik do paska
        public int AllCount => AllRowsInternal.Count;
        public int FilteredCount => FilteredRows.Count;

        // FILTRY
        [ObservableProperty] private string bookTitleFilter = string.Empty;          // nowy: wpisywany tytuł
        [ObservableProperty] private string borrowerOrPhoneFilter = string.Empty;    // nowy: czytelnik + telefon
        [ObservableProperty] private DateTimeOffset? dueFrom;
        [ObservableProperty] private DateTimeOffset? dueTo;

        public GlobalTableViewModel() { Load(); }

        [RelayCommand] private void Refresh() => Load();

        [RelayCommand]
        private void ApplyFilters()
        {
            IEnumerable<Row> q = AllRowsInternal;

            if (!string.IsNullOrWhiteSpace(BookTitleFilter))
            {
                var needle = BookTitleFilter.Trim();
                q = q.Where(r => (r.BookTitle ?? "").Contains(needle, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(BorrowerOrPhoneFilter))
            {
                var needle = BorrowerOrPhoneFilter.Trim();
                q = q.Where(r =>
                    (r.BorrowerName ?? "").Contains(needle, StringComparison.OrdinalIgnoreCase) ||
                    (r.BorrowerPhone ?? "").Contains(needle, StringComparison.OrdinalIgnoreCase)
                );
            }

            if (DueFrom.HasValue)
            {
                var from = DueFrom.Value.Date; // DateTimeOffset -> Date (bez czasu)
                q = q.Where(r => r.DueAt >= from);
            }

            if (DueTo.HasValue)
            {
                var end = DueTo.Value.Date.AddDays(1).AddTicks(-1);
                q = q.Where(r => r.DueAt <= end);
            }

            FilteredRows.Clear();
            foreach (var r in q) FilteredRows.Add(r);
            OnPropertyChanged(nameof(FilteredCount));
        }

        [RelayCommand]
        private void ClearFilters()
        {
            BookTitleFilter = string.Empty;
            BorrowerOrPhoneFilter = string.Empty;
            DueFrom = null;
            DueTo = null;

            FilteredRows.Clear();
            foreach (var r in AllRowsInternal) FilteredRows.Add(r);
            OnPropertyChanged(nameof(FilteredCount));
        }

        private void Load()
        {
            // 1) książki
            var books = new List<Book>();
            if (File.Exists(BooksPath))
            {
                var txt = File.ReadAllText(BooksPath);
                books = JsonConvert.DeserializeObject<List<Book>>(txt) ?? new();
            }
            var bookById = books.ToDictionary(b => b.Id, b => b);

            // 2) wypożyczenia
            var loans = new List<Loan>();
            if (File.Exists(LoansPath))
            {
                var txt = File.ReadAllText(LoansPath);
                loans = JsonConvert.DeserializeObject<List<Loan>>(txt) ?? new();
            }

            // 3) płaskie wiersze
            AllRowsInternal = loans
                .OrderByDescending(l => l.BorrowedAt)
                .Select(l =>
                {
                    bookById.TryGetValue(l.BookId, out var book);
                    return new Row
                    {
                        Id = l.Id,
                        BookTitle = book?.Title ?? "(nieznana książka)",
                        BookAuthor = book?.Author ?? "",
                        BorrowerName = l.BorrowerName ?? "",
                        BorrowerPhone = l.BorrowerPhone ?? "",
                        Notes = l.Notes ?? "",
                        BorrowedAt = l.BorrowedAt,
                        DueAt = l.DueAt,
                        ReturnedAt = l.ReturnedAt
                    };
                })
                .ToList();


            FilteredRows.Clear();
            foreach (var r in AllRowsInternal) FilteredRows.Add(r);

            OnPropertyChanged(nameof(AllCount));
            OnPropertyChanged(nameof(FilteredCount));
        }
    }
}
