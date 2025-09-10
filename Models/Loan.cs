
using System;

namespace ProKS1.Models
{
    public class Loan
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public DateTime BorrowedAt { get; set; }
        public DateTime DueAt { get; set; }
        public DateTime? ReturnedAt { get; set; }
        public string BorrowerName { get; set; } = string.Empty;
        public string BorrowerPhone { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
    }
}
