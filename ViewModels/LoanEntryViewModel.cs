using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProKS1.Models;
using ProKS1.Services;
using System;
using System.Linq;

namespace ProKS1.ViewModels
{
    public partial class LoanEntryViewModel : ViewModelBase
    {
        private readonly LoanService _loanSvc = new();
        private readonly BookService _bookSvc = new();
        private readonly Window _host;

        public Book SelectedBook { get; }

        [ObservableProperty] private string borrowerName = string.Empty;
        [ObservableProperty] private string borrowerPhone = string.Empty;

        [ObservableProperty] private DateTimeOffset? borrowedAt = DateTimeOffset.Now;
        [ObservableProperty] private DateTimeOffset? dueAt = DateTimeOffset.Now.AddDays(14);

        [ObservableProperty] private string notes = string.Empty;
        [ObservableProperty] private string? errorMessage;

        public LoanEntryViewModel(Book book, Window host)
        {
            SelectedBook = book;
            _host = host;
        }

        [RelayCommand]
        private void SaveLoan()
        {
           
            var active = _loanSvc.GetAll().Count(l => l.BookId == SelectedBook.Id && l.ReturnedAt == null);
            if (active >= SelectedBook.CopiesTotal)
            {
                ErrorMessage = "Brak dostępnych egzemplarzy dla tej książki.";
                return;
            }

            var l = new Loan
            {
                BookId = SelectedBook.Id,
                BorrowedAt = (BorrowedAt ?? DateTimeOffset.Now).DateTime,
                DueAt = (DueAt ?? DateTimeOffset.Now.AddDays(14)).DateTime,
                BorrowerName = BorrowerName,
                BorrowerPhone = BorrowerPhone,
                Notes = Notes
            };
            _loanSvc.Add(l);
            _host.Close();
        }
    }
}
