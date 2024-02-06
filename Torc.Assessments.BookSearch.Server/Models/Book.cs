namespace Torc.Assessments.BookSearch.Server.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public int TotalCopies { get; set; }
        public int CopiesInUse { get; set; }
        public string Type { get; set; }
        public string Isbn { get; set; }
        public string Category { get; set; }
        public bool IsOwned { get; set; }
        public bool IsLoved { get; set; }
        public bool WishList { get; set; }
    }
}
