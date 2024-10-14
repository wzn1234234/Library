using Library.Server.DBContexts.Mapping;
using Library.Server.Models.Entity;
using Library.Server.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Library.Server.DBContexts
{
    public class AppDBContext : IdentityDbContext<
        AppUser,
        AppRole,
        int,
        AppUserClaim,
        AppUserRole,
        AppUserLogin,
        AppRoleClaim,
        AppUserToken>
    {

        public DbSet<Book> Books { get; set; }
        public DbSet<UserBookCheckOut> UserBookCheckOuts { get; set; }
        public DbSet<UserBookReview> UserBookReviews { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BookMap());
            builder.ApplyConfiguration(new UserBookCheckOutMap());
            builder.ApplyConfiguration(new UserBookReviewMap());
            base.OnModelCreating(builder);
            
            builder.UseIdentityColumns();

            new DBInitializer(builder).Seed();
        }

        public static readonly ILoggerFactory PropertyAppLoggerFactory =
            LoggerFactory.Create(builder =>
                builder.AddFilter((category, level) =>
                category == DbLoggerCategory.Database.Command.Name && (level == LogLevel.Warning))
                .AddConsole());
    }
}