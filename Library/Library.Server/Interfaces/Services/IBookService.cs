using Library.Server.Models.Entity;
using Library.Server.ViewModels.BookViewModels;

namespace Library.Server.Interfaces.Services
{
    public interface IBookService : IEntityService<Book>
    {
        Task<List<FeaturedBookModel>> GetFeaturedBooks(BookFilterModel filterModel);
        Task<BookDetailModel> GetBook(int bookId);
        Task<bool> AddBook(BookDetailModel model);
        Task<bool> EditBook(BookDetailModel model);
        Task<bool> RemoveBook(int bookId);
        Task<BookDetailModel> CheckoutBook(int bookId);
        Task<BookDetailModel> ReturnBook(int bookId);
        Task<BookDetailModel> ReviewBook(BookReviewModel model);
    }
}
