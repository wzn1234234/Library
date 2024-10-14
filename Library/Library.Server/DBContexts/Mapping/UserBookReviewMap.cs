using Library.Server.Models.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Library.Server.DBContexts.Mapping
{
    public class UserBookReviewMap : IEntityTypeConfiguration<UserBookReview>
    {
        public void Configure(EntityTypeBuilder<UserBookReview> builder)
        {
            builder.ToTable("UserBookReviews");
            builder.HasKey("Id");
            builder.HasOne(i => i.Book).WithMany(m => m.UserBookReviews).HasForeignKey(m => m.BookId).HasPrincipalKey(i => i.Id);
            builder.HasOne(i => i.User).WithMany(m => m.UserBookReviews).HasForeignKey(m => m.UserId).HasPrincipalKey(i => i.Id);
        }
    }
}