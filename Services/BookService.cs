using ProKS1.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;

namespace ProKS1.Services
{
    public class BookService
    {
        private readonly string file = Path.Combine(AppContext.BaseDirectory, "books.json");
        private readonly List<Book> _books;

        public BookService()
        {
            if (File.Exists(file))
            {
                _books = JsonConvert.DeserializeObject<List<Book>>(File.ReadAllText(file)) ?? new();
            }
            else
            {
                _books = new()
                {
                    new(){ Id=1, Title="Pan Tadeusz", Author="Adam Mickiewicz", Year=1834, Isbn="978-83-01-00000-1", Genre="Epopeja", CopiesTotal=3 },
                    new(){ Id=2, Title="Lalka", Author="Bolesław Prus", Year=1890, Isbn="978-83-01-00000-2", Genre="Powieść", CopiesTotal=2 },
                    new(){ Id=3, Title="Quo Vadis", Author="Henryk Sienkiewicz", Year=1896, Isbn="978-83-01-00000-3", Genre="Powieść historyczna", CopiesTotal=4 }
                };
                Save();
            }
        }

        public List<Book> GetAll() => _books;

        public Book Add(Book b)
        {
            b.Id = _books.Count > 0 ? _books.Max(x => x.Id) + 1 : 1;
            _books.Add(b);
            Save();
            return b;
        }

        public bool Remove(int id)
        {
            var it = _books.FirstOrDefault(x => x.Id == id);
            if (it == null) return false;
            _books.Remove(it);
            Save();
            return true;
        }

        public void Update(Book b)
        {
            var it = _books.FirstOrDefault(x => x.Id == b.Id);
            if (it == null) return;
            it.Title = b.Title; it.Author = b.Author; it.Isbn = b.Isbn; it.Year = b.Year; it.CopiesTotal = b.CopiesTotal; it.Genre = b.Genre;
            Save();
        }

        private void Save() =>
            File.WriteAllText(file, JsonConvert.SerializeObject(_books, Formatting.Indented));
    }
}
