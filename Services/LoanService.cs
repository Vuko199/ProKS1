using ProKS1.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;

namespace ProKS1.Services
{
    public class LoanService
    {
        private readonly string file = Path.Combine(AppContext.BaseDirectory, "loans.json");
        private List<Loan> _loans;

        public LoanService()
        {
            if (File.Exists(file))
                _loans = JsonConvert.DeserializeObject<List<Loan>>(File.ReadAllText(file)) ?? new();
            else _loans = new();
        }

        public List<Loan> GetAll() => _loans;

        public void Add(Loan l)
        {
            l.Id = _loans.Count > 0 ? _loans.Max(x => x.Id) + 1 : 1;
            _loans.Add(l);
            Save();
        }

        public void Update(Loan l)
        {
            var it = _loans.FirstOrDefault(x => x.Id == l.Id);
            if (it != null)
            {
                it.BookId = l.BookId;
                it.BorrowedAt = l.BorrowedAt;
                it.DueAt = l.DueAt;
                it.ReturnedAt = l.ReturnedAt;
                it.BorrowerName = l.BorrowerName;
                it.BorrowerPhone = l.BorrowerPhone;
                it.Notes = l.Notes;
                Save();
            }
        }

        public void Delete(int id)
        {
            var it = _loans.FirstOrDefault(x => x.Id == id);
            if (it != null) { _loans.Remove(it); Save(); }
        }

        private void Save() => File.WriteAllText(file, JsonConvert.SerializeObject(_loans, Formatting.Indented));
    }
}
