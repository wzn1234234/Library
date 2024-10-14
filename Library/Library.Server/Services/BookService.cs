using Library.Server.DBContexts;
using Library.Server.Extensions;
using Library.Server.Interfaces.Services;
using Library.Server.Models.Entity;
using Library.Server.Models.Identity;
using Library.Server.ViewModels.BookViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Net;
using static System.Reflection.Metadata.BlobBuilder;

namespace Library.Server.Services
{
    public class BookService : EntityService<Book>, IBookService
    {
        public IUserBookCheckOutService _userBookCheckOutService { get; set; }
        public IUserBookReviewService _userBookReviewService { get; set; }
        public UserManager<AppUser> _userManager { get; }
        public IHttpContextAccessor _httpContextAccessor { get; }

        public BookService(
            AppDBContext DbContext,
            IUserBookCheckOutService userBookCheckOutService,
            IUserBookReviewService userBookReviewService,
            UserManager<AppUser> userManager,
            IHttpContextAccessor httpContextAccessor
            ) : base(DbContext)
        {
            _userBookCheckOutService = userBookCheckOutService;
            _userBookReviewService = userBookReviewService;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public Task<List<FeaturedBookModel>> GetFeaturedBooks(BookFilterModel filterModel)
        {
            var books = QueryableList;

            if (!string.IsNullOrEmpty(filterModel.Title))
            {
                books = books.Where(c => c.Title.Contains(filterModel.Title));
            }

            if (!string.IsNullOrEmpty(filterModel.Author))
            {
                books = books.Where(c => c.Author.Contains(filterModel.Author));
            }

            var notReturnedBookIds = _userBookCheckOutService.QueryableList.Where(c => !c.IsReturned).Select(c=>c.BookId).ToList();
            if (filterModel.Availability == 0)
            {
                books = books.Where(c => notReturnedBookIds.Contains(c.Id));
            }
            else if (filterModel.Availability == 1){
                books = books.Where(c => !notReturnedBookIds.Contains(c.Id));
            }

            var bookReviews = _userBookReviewService.QueryableList.GroupBy(c=>c.BookId).Select(g => new {
                BookId = g.Key,
                AverageRate = (int) g.Average(s => s.Rate)
            }
            );

            var bookPaths = books.Select(c => new { Id = c.Id, Path = c.CoverImagePath});

            var models = books.Select(c => new FeaturedBookModel()
            {
                Id = c.Id,
                Title = c.Title,
                Author = c.Author,
                Description = c.Description,
                Availability = !notReturnedBookIds.Contains(c.Id),
                AverageRate = bookReviews.Any(f => f.BookId == c.Id) ? bookReviews.First(f => f.BookId == c.Id).AverageRate : 0,
                CoverImagePath = c.CoverImagePath
            
            });

            if (filterModel.Random && models.Count() > 3)
            {
                models = models.OrderBy(_ => Guid.NewGuid()).Take(3);
            }

            if(filterModel.SortData != null)
            {
                if(filterModel.SortData == "Title")
                    models = models.OrderBy(c=>c.Title);
                else if (filterModel.SortData == "Author")
                    models = models.OrderBy(c => c.Author);
                else if (filterModel.SortData == "Availability")
                    models = models.OrderBy(c => c.Availability);
            }

            return models.ToListAsync();
        }

        public async Task<BookDetailModel> GetBook(int bookId)
        {
            if (!QueryableList.Any(c => c.Id == bookId))
                return null;

            var book = await GetByIdAsync(bookId);

            var bookReviews = _userBookReviewService.QueryableList.Where(c => c.BookId == bookId);
            var averageRate = bookReviews.Count() == 0 ? 0 : ((int)(bookReviews.Sum(c => c.Rate) / bookReviews.Count()));
            var availability = !_userBookCheckOutService.QueryableList.Any(c => !c.IsReturned);
            var bookReviewDetails = bookReviews.Select(c => new BookReviewDetailModel()
            {
                BookId = bookId,
                Review = c.Review,
                Rate = c.Rate,
                FirstName = c.User.FirstName,
                LastName = c.User.LastName
            });

            return new BookDetailModel()
            {
                Id = bookId,
                Author = book.Author,
                Availability = availability,
                AverageRate = averageRate,
                Category = book.Category,
                CoverImagePath = book.CoverImagePath,
                Description = book.Description,
                ISBN = book.ISBN,
                PageCount = book.PageCount,
                PublicationDate = book.PublicationDate,
                Publisher = book.Publisher,
                Title = book.Title,
                UserBookReviews = bookReviewDetails.ToList()
            };
        }

        public async Task<bool> AddBook(BookDetailModel model)
        {
            try
            {
                var nextFileName = Directory.GetFiles("~\\images\\")
                .Select(c => int.Parse(c.Substring(0, c.IndexOf('.')))).Max() + 1;
                var filePath = model.CoverImage.Name.Substring(model.CoverImage.Name.IndexOf('.'), model.CoverImage.Name.Length);
                using (var fileStream = new FileStream(nextFileName.ToString() + filePath, FileMode.Create, FileAccess.Write))
                {
                    model.CoverImage.CopyTo(fileStream);
                }

                var userName = _httpContextAccessor.HttpContext.User.Identity.Name;

                var book = new Book()
                {
                    Author = model.Author,
                    Category = model.Category,
                    Description = model.Description,
                    ISBN = model.ISBN,
                    PageCount = model.PageCount,
                    PublicationDate = model.PublicationDate,
                    Publisher = model.Publisher,
                    Title = model.Title,
                    CoverImagePath = filePath,
                    CreatedBy = userName,
                    CreatedDate = DateTime.Now,
                    UpdatedBy = userName,
                    UpdatedDate = DateTime.Now
                };
                await AddAsync(book);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> EditBook(BookDetailModel model)
        {
            try
            {
                var nextFileName = Directory.GetFiles("~\\images\\")
                .Select(c => int.Parse(c.Substring(0, c.IndexOf('.')))).Max() + 1;
                var filePath = model.CoverImage.Name.Substring(model.CoverImage.Name.IndexOf('.'), model.CoverImage.Name.Length);
                using (var fileStream = new FileStream(nextFileName.ToString() + filePath, FileMode.Create, FileAccess.Write))
                {
                    model.CoverImage.CopyTo(fileStream);
                }
                //Todo Delete old cover image

                var userName = _httpContextAccessor.HttpContext.User.Identity.Name;
                var book = await GetByIdAsync(model.Id);

                book.Author = model.Author;
                book.Category = model.Category;
                book.Description = model.Description;
                book.ISBN = model.ISBN;
                book.PageCount = model.PageCount;
                book.PublicationDate = model.PublicationDate;
                book.Publisher = model.Publisher;
                book.Title = model.Title;
                book.CoverImagePath = filePath;
                book.UpdatedBy = userName;
                book.UpdatedDate = DateTime.Now;
                
                await UpdateAsync(book);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> RemoveBook(int bookId)
        {
            try
            {
                //Todo Delete old cover image
                await DeleteAsync(bookId);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<BookDetailModel> CheckoutBook(int bookId)
        {
            var canCheckOut = !_userBookCheckOutService.QueryableList.Any(c => c.BookId == bookId && !c.IsReturned);

            if (canCheckOut) {
                var userName = _httpContextAccessor.HttpContext.User.Identity.Name;
                var userId = _userManager.Users.First(c => c.UserName == _httpContextAccessor.HttpContext.User.Identity.Name).Id;

                var checkOut = new UserBookCheckOut()
                {
                    UserId = userId,
                    BookId = bookId,
                    IsReturned = false,
                    CheckOutDate = DateTime.Now,
                    CreatedBy = userName,
                    CreatedDate = DateTime.Now,
                    UpdatedBy = userName,
                    UpdatedDate = DateTime.Now
                };
                await _userBookCheckOutService.AddAsync(checkOut);
            }
            
            return await GetBook(bookId);
        }

        public async Task<BookDetailModel> ReturnBook(int bookId)
        {
            var canReturn = _userBookCheckOutService.QueryableList.Any(c => c.BookId == bookId && !c.IsReturned);
            if (canReturn)
            {
                var userName = _httpContextAccessor.HttpContext.User.Identity.Name;
                var checkOut = _userBookCheckOutService.QueryableList.Where(c => c.BookId == bookId && !c.IsReturned).First();

                checkOut.IsReturned = true;
                checkOut.UpdatedBy = userName;
                checkOut.UpdatedDate = DateTime.Now;
               
                await _userBookCheckOutService.UpdateAsync(checkOut);
            }
            return await GetBook(bookId);

        }

        public async Task<BookDetailModel> ReviewBook(BookReviewModel model)
        {
            var userName = _httpContextAccessor.HttpContext.User.Identity.Name;
            var userId = _userManager.Users.First(c=> c.UserName == _httpContextAccessor.HttpContext.User.Identity.Name).Id;

            var review = new UserBookReview()
            {
                UserId = userId,
                BookId = model.BookId,
                Review = model.Review,
                Rate = model.Rate,
                CreatedBy = userName,
                CreatedDate = DateTime.Now,
                UpdatedBy = userName,
                UpdatedDate = DateTime.Now
            };
            await _userBookReviewService.AddAsync(review);

            return await GetBook(model.BookId);
        }
    }
}
