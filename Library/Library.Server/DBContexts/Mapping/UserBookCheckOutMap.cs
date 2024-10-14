using Library.Server.Models.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Library.Server.DBContexts.Mapping
{
    public class UserBookCheckOutMap : IEntityTypeConfiguration<UserBookCheckOut>
    {
        public void Configure(EntityTypeBuilder<UserBookCheckOut> builder)
        {
            builder.ToTable("UserBookCheckOuts");
            builder.HasKey("Id");
            builder.HasOne(i => i.Book).WithMany(m => m.UserBookCheckOuts).HasForeignKey(m => m.BookId).HasPrincipalKey(i => i.Id);
            builder.HasOne(i => i.User).WithMany(m => m.UserBookCheckOuts).HasForeignKey(m => m.UserId).HasPrincipalKey(i => i.Id);
        }
    }
}