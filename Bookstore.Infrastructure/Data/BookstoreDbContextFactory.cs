using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

 namespace Bookstore.Infrastructure.Data;

  public class BookstoreDbContextFactory : IDesignTimeDbContextFactory<BookStoreDbContext>
  {


    public BookStoreDbContext CreateDbContext(string[] args)
    {


   
      var optionsBuilder = new DbContextOptionsBuilder<BookStoreDbContext>();
      

      optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=BookstoreDb;Trusted_Connection=True;TrustServerCertificate=True");



      return new BookStoreDbContext(optionsBuilder.Options);
      


    }

  }