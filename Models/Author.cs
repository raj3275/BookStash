namespace BookStash.Models
{
    public class Author
    {
        public int AuthorID { get; set; }
        public string AuthorName { get; set; }
        public string AboutAuthor { get; set; }
        public List<Book> BookList { get; set; } = new List<Book>();
    }
}
