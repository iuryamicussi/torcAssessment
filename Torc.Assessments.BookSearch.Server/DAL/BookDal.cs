using Torc.Assessments.BookSearch.Server.Models;

namespace Torc.Assessments.BookSearch.Server.DAL
{
    public interface IBookDal
    {
        IEnumerable<Book> GetByAuthor(string author);
        IEnumerable<Book> GetByIsbn(string isbn);
        IEnumerable<Book> GetOwned();
        IEnumerable<Book> GetIsLoved();
        IEnumerable<Book> GetInWishList();
    }

    public class BookDal : IBookDal
    {
        private readonly ISqlServerConnector _connector;

        public BookDal(ISqlServerConnector connector)
        {
            _connector = connector;
        }

        public IEnumerable<Book> GetByAuthor(string author)
        {
            return _connector.RunQuery<Book>("Select * From Books Where AuthorFirstName Like '%@author%' Or AuthorLastName Like '%@author%'", new { author = author });
        }

        public IEnumerable<Book> GetByIsbn(string isbn)
        {
            return _connector.RunQuery<Book>("Select * From Books Where Isbn = '@isbn'", new { isbn });
        }

        public IEnumerable<Book> GetOwned()
        {
            return _connector.RunQuery<Book>("Select * From Books Where IsOwned = true");
        }

        public IEnumerable<Book> GetIsLoved()
        {
            return _connector.RunQuery<Book>("Select * From Books Where IsLoved = true");
        }

        public IEnumerable<Book> GetInWishList()
        {
            return _connector.RunQuery<Book>("Select * From Books Where WishList = true");
        }
    }
}
