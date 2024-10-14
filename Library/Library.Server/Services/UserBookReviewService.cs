using Library.Server.DBContexts;
using Library.Server.Interfaces.Services;
using Library.Server.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace Library.Server.Services
{
    public class UserBookReviewService : EntityService<UserBookReview>, IUserBookReviewService
    {
        public UserBookReviewService(AppDBContext DbContext) : base(DbContext)
        {
        }
    }
}
