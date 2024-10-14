using Library.Server.Interfaces.Services;
using Library.Server.Services;

namespace Library.Server.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddScoped<IUserBookCheckOutService, UserBookCheckOutService>();
            services.AddScoped<IUserBookReviewService, UserBookReviewService>();
            services.AddScoped<IBookService, BookService>();

            return services;
        }
    }
}
