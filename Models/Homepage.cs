namespace BookStash.Models
{
    public class Homepage
    {
        public int HomepageID { get; set; }
        public int BookID { get; set; }
        public string BookName { get; set; }
        public int AuthorID { get; set; }
        public string AuthorName { get; set; }
        public Book Book { get; set; }
        public Author Author { get; set; }
    }
}
