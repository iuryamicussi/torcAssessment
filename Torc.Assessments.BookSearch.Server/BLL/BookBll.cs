using Torc.Assessments.BookSearch.Server.DAL;
using Torc.Assessments.BookSearch.Server.Models;

namespace Torc.Assessments.BookSearch.Server.BLL
{
    public interface IBookBll
    {
        IEnumerable<Book> GetByAuthor(string author);
        IEnumerable<Book> GetByIsbn(string isbn);
        IEnumerable<Book> GetOwned();
        IEnumerable<Book> GetIsLoved();
        IEnumerable<Book> GetInWishList();
    }

    public class BookBll : IBookBll
    {
        private readonly IBookDal _bookDal;

        public BookBll(IBookDal bookDal)
        {
            _bookDal = bookDal;
        }

        public IEnumerable<Book> GetByAuthor(string author)
        {
            return _bookDal.GetByAuthor(author);
        }

        public IEnumerable<Book> GetByIsbn(string isbn)
        {
            return _bookDal.GetByIsbn(isbn);
        }

        public IEnumerable<Book> GetOwned()
        {
            return _bookDal.GetOwned();
        }

        public IEnumerable<Book> GetIsLoved()
        {
            return _bookDal.GetIsLoved();
        }

        public IEnumerable<Book> GetInWishList()
        {
            return _bookDal.GetInWishList();
        }
    }
}
