using Microsoft.AspNetCore.Mvc;
using Torc.Assessments.BookSearch.Server.BLL;
using Torc.Assessments.BookSearch.Server.Models;

namespace Torc.Assessments.BookSearch.Server.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class BookSearchController : ControllerBase
    {

        private readonly ILogger<BookSearchController> _logger;
        private readonly IBookBll _bookService;

        public BookSearchController(ILogger<BookSearchController> logger, IBookBll bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }

        [HttpGet(Name = "GetByAuthor", Order = 1)]
        public IEnumerable<Book> GetByAuthor(string author)
        {
            return _bookService.GetByAuthor(author).ToArray();
        }

        [HttpGet(Name = "GetByIsbn", Order = 2)]
        public IEnumerable<Book> GetByIsbn(string isbn)
        {
            return _bookService.GetByIsbn(isbn);
        }

        [HttpGet(Name = "GetOwned", Order = 3)]
        public IEnumerable<Book> GetOwned()
        {
            return _bookService.GetOwned();
        }

        [HttpGet(Name = "GetLoved", Order = 4)]
        public IEnumerable<Book> GetLoved()
        {
            return _bookService.GetIsLoved();
        }

        [HttpGet(Name = "GetWishList", Order = 5)]
        public IEnumerable<Book> GetWishList()
        {
            return _bookService.GetInWishList();
        }
    }
}
