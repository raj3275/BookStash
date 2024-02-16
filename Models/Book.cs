namespace BookStash.Models
{
    public class Book
    {
        public int BookID { get; set; }
        public string BookName { get; set; }
        public DateTime DatePub { get; set; }
        public string Publisher { get; set; }
        public string Language { get; set; }
        public string Paperback { get; set; }
        public string ISBN10 { get; set; }
        public string ISBN13 { get; set; }
        public string ItemWeight { get;}
        public string Dimensions { get; set; }
        public string BestSellersRank { get; set; }
        public string CustomerReviews { get; set;}
        public List<Author> AuthorsList { get; set;} = new List<Author>();
    }
}
