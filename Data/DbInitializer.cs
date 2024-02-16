using BookStash.Data;
using BookStash.Models;
using System.Diagnostics;
using System.Security.Policy;

namespace BookStash.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ExamContext context)
        {
            // Look for any Books.
            if (context.Books.Any())
            {
                return;   // DB has been seeded
            }

            var Books = new Book[]
            {
                new Book{BookName = "Outlive",DatePub = DateTime.Parse("2023-03-28"),Publisher = "Harmony",Language = "English",Paperback = "Yes",ISBN10 = "1785044559",ISBN13 = "978-1785044557",Dimensions = "6.02 x 1.57 x 9.21 inches",BestSellersRank = "#1,290 in Books",CustomerReviews = "4.6"},
                new Book{BookName = "Atomic Habits",DatePub = DateTime.Parse("2018-10-16"),Publisher = "Avery",Language = "English",Paperback = "Yes",ISBN10 = "1847941842",ISBN13 = "978-1847941848",Dimensions = "0.04 x 0.04 x 0.04 inches",BestSellersRank = "#424 in Books",CustomerReviews = "4.8"},
                new Book{BookName="Spare",DatePub=DateTime.Parse("2023-09-01"),Publisher="Random House Large Print",Language="English",Paperback = "Yes",ISBN10="0593677862",ISBN13="978-0593677865",Dimensions="6.05 x 1.16 x 9.18 inches",BestSellersRank="#16,814 ",CustomerReviews="4.5"},
                new Book{BookName="The Body Keeps the Score",DatePub=DateTime.Parse("2015-09-08"),Publisher="Penguin Books",Language="English",Paperback = "Yes",ISBN10="0143127748",ISBN13="978-0143127741",Dimensions="1.1 x 5.4 x 8.4 inches",BestSellersRank="#16",CustomerReviews="4.8"},
                new Book{BookName = "Too Late", DatePub = DateTime.Parse("2023-06-27"), Publisher = "Grand Central Publishing", Language = "English",Paperback = "Yes", ISBN10 = "1538756595", ISBN13 = "978-1538756591", Dimensions = "13.97 x 2.54 x 20.83 cm", BestSellersRank = "#103 in Books", CustomerReviews = "4.3" }
            };

            context.Books.AddRange(Books);
            context.SaveChanges();

            var Authors = new Author[]
            {
                new Author{AuthorName="Peter Attia MD",AboutAuthor="Peter Attia is a Canadian-American physician known for his expertise in researching life extension and enhancing people's overall health."},
                new Author{AuthorName="James Clear",AboutAuthor="James Clear is a writer and speaker focused on habits, decision making, and continuous improvement. He is the author of the #1 New York Times bestseller, Atomic Habits. The book has sold over 5 million copies worldwide and has been translated into more than 50 languages." },
                new Author{AuthorName="Prince Harry",AboutAuthor="Prince Harry, Duke of Sussex, KCVO is a member of the British royal family. He is the younger son of King Charles III and Diana, Princess of Wales." },
                new Author{AuthorName="Bessel van der Kolk",AboutAuthor="Bessel van der Kolk is a psychiatrist, author, researcher and educator based in Boston, United States. Since the 1970s his research has been in the area of post-traumatic stress. He is the author of The New York Times best seller, The Body Keeps the Score." },
                new Author{AuthorName="Colleen Hoover",AboutAuthor="Colleen Hoover is the #1 New York Times and International bestselling author of multiple novels and novellas. She lives in Texas with her husband and their three boys. She is the founder of The Bookworm Box, a non-profit book subscription service and bookstore in Sulphur Springs, Texas."}
            };

            context.Authors.AddRange(Authors);
            context.SaveChanges();

            var Homepages = new Homepage[]
            {
                new Homepage{BookName="Outlive",AuthorName="Peter Attia MD"},
                new Homepage{BookName="Atomic Habits",AuthorName="James Clear"},
                new Homepage{BookName="Spare",AuthorName="Prince Harry"},
                new Homepage{BookName="The Body Keeps the Score",AuthorName="Bessel van der Kolk"},
                new Homepage{BookName="Too Late",AuthorName="Colleen Hoover"}

            };

            context.Homepages.AddRange(Homepages);
            context.SaveChanges();
        }
    }
}