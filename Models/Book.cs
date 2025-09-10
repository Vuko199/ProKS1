namespace ProKS1.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public string Isbn { get; set; } = string.Empty;
        public int Year { get; set; }
        public int CopiesTotal { get; set; } = 1;
    }
}
