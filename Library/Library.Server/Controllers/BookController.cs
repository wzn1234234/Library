using Library.Server.Interfaces.Services;
using Library.Server.Models.Entity;
using Library.Server.ViewModels.BookViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Library.Server.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IBookService _bookService;

        public BookController(
            ILogger<WeatherForecastController> logger,
            IBookService bookService
            )
        {
            _logger = logger;
            _bookService = bookService;
        }

        /// <summary>
        /// Get all books by filter
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetBooks")]
        public async Task<IEnumerable<FeaturedBookModel>> GetBooks([FromQuery]BookFilterModel filter)
        {
            try
            {
                return await _bookService.GetFeaturedBooks(filter);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Get a book detail by id
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetBook")]
        public async Task<BookDetailModel> GetBook(int bookId)
        {
            try
            {
                return await _bookService.GetBook(bookId);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Add a new book
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Librarian")]
        [HttpPost("AddBook")]
        public async Task<bool> AddBook([FromBody] BookDetailModel model)
        {
            try
            {
                return await _bookService.AddBook(model);
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Edit a book detail
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Librarian")]
        [HttpPost("EditBook")]
        public async Task<bool> EditBook([FromBody] BookDetailModel model)
        {
            try
            {
                return await _bookService.EditBook(model);
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Remove a book
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Librarian")]
        [HttpPost("RemoveBook")]
        public async Task<bool> RemoveBook(int bookId)
        {
            try
            {
                return await _bookService.RemoveBook(bookId);
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Checkout a book
        /// </summary>
        /// <returns></returns>
        [HttpPost("CheckoutBook")]
        public async Task<BookDetailModel> CheckoutBook(int bookId)
        {
            try
            {
                return await _bookService.CheckoutBook(bookId);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Return a book
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Librarian")]
        [HttpPost("ReturnBook")]
        public async Task<BookDetailModel> ReturnBook(int bookId)
        {
            try
            {
                return await _bookService.ReturnBook(bookId);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Review a book
        /// </summary>
        /// <returns></returns>
        [HttpPost("ReviewBook")]
        public async Task<BookDetailModel> ReviewBook([FromBody] BookReviewModel model)
        {
            try
            {
                return await _bookService.ReviewBook(model);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
