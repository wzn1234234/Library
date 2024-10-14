using Library.Server.DBContexts;
using Library.Server.Interfaces.Services;
using Library.Server.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace Library.Server.Services
{
    public class UserBookCheckOutService : EntityService<UserBookCheckOut>, IUserBookCheckOutService
    {
        public UserBookCheckOutService(AppDBContext DbContext) : base(DbContext)
        {
        }
    }
}
