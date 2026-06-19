using Bookstore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Infrastructure.Data;

public class BookStoreDbContext : DbContext
{
    public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
        : base(options)
    {
    }

       public DbSet<Author> Authors {get; set;}
    
       public DbSet<Book> Books {get; set;}

   protected override void OnModelCreating(ModelBuilder builder)
{

   builder.Entity<Book>()
          .HasOne(b => b.Author)
          .WithMany(a => a.Books)
          .HasForeignKey(b => b.AuthorId);

  builder.Entity<Book>()
         .Property(b => b.Price)
         .HasPrecision(18,2);


}
}