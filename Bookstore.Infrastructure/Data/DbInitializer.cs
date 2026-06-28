using Bookstore.Domain.Entities;


namespace Bookstore.Infrastructure.Data;


public static class DbInitializer
{
    public static async Task InitializeAsync(BookStoreDbContext context)
    {
        // TODO: 1. Ensure database is created (apply migrations if needed)
     await context.Database.EnsureCreatedAsync();
        // TODO: 2. Check if tables have data (context.Authors.Any())
     if(context.Authors.Any()&& context.Books.Any()) return;
    
        // TODO: 3. If no data, seed authors and books
       var authors = new List<Author>
     {
      new Author {FirstName ="Robert", LastName = "Martin", Biography = "Author of Clean Code and Clean Architecture"},
      new Author {FirstName = "David", LastName = "Thomas", Biography = "Author of The Pragmatic Programmer"},
      new Author {FirstName = "Kent ", LastName = "Beck", Biography = "Author of The Test-Driven Development"},
      new Author {FirstName = "Eric ", LastName = "Evans ", Biography = "Author of the Domain-Driven Design"},
      new Author {FirstName = "Michael ", LastName = "Feathers", Biography = "Author of The Working Effectively with Legacy Code"}
     };

   await context.Authors.AddRangeAsync(authors);

   await context.SaveChangesAsync();

  var books = new List<Book>
{
    new Book
    {
        Title = "Clean Code",
        Description = "A handbook of agile software craftsmanship",
        Price = 42.99m,
        Quantity = 100,
        ISBN = "978-0132350884",
        CoverImagePath = "/covers/clean-code.jpg",
        AuthorId = 1
    },
    new Book
    {
        Title = "The Pragmatic Programmer",
        Description = "From Journeyman to Master",
        Price = 35.99m,
        Quantity = 80,
        ISBN = "978-0201616224",
        CoverImagePath = "/covers/pragmatic.jpg",
        AuthorId = 2
    },
    new Book
    {
        Title = "Design Patterns",
        Description = "Elements of Reusable Object-Oriented Software",
        Price = 49.99m,
        Quantity = 60,
        ISBN = "978-0201633610",
        CoverImagePath = "/covers/design-patterns.jpg",
        AuthorId = 3
    },
    new Book
    {
        Title = "Code Complete",
        Description = "A Practical Handbook of Software Construction",
        Price = 39.99m,
        Quantity = 90,
        ISBN = "978-0735619678",
        CoverImagePath = "/covers/code-complete.jpg",
        AuthorId = 4
    },
    new Book
    {
        Title = "Refactoring",
        Description = "Improving the Design of Existing Code",
        Price = 44.99m,
        Quantity = 70,
        ISBN = "978-0201485677",
        CoverImagePath = "/covers/refactoring.jpg",
        AuthorId = 5
    },
    new Book
    {
        Title = "Head First Design Patterns",
        Description = "A Brain-Friendly Guide",
        Price = 32.99m,
        Quantity = 85,
        ISBN = "978-0596007126",
        CoverImagePath = "/covers/head-first-design-patterns.jpg",
        AuthorId = 3
    },
    new Book
    {
        Title = "Clean Architecture",
        Description = "A Craftsman's Guide to Software Structure and Design",
        Price = 37.99m,
        Quantity = 65,
        ISBN = "978-0134494166",
        CoverImagePath = "/covers/clean-architecture.jpg",
        AuthorId = 1
    },
    new Book
    {
        Title = "Domain-Driven Design",
        Description = "Tackling Complexity in the Heart of Software",
        Price = 47.99m,
        Quantity = 55,
        ISBN = "978-0321125217",
        CoverImagePath = "/covers/domain-driven-design.jpg",
        AuthorId = 5
    },
    new Book
    {
        Title = "Working Effectively with Legacy Code",
        Description = "A Guide to Working with Legacy Code",
        Price = 41.99m,
        Quantity = 75,
        ISBN = "978-0131177055",
        CoverImagePath = "/covers/working-effectively-with-legacy-code.jpg",
        AuthorId = 2
    },
    new Book
    {
        Title = "Test-Driven Development",
        Description = "By Example",
        Price = 38.99m,
        Quantity = 70,
        ISBN = "978-0321146533",
        CoverImagePath = "/covers/test-driven-development.jpg",
        AuthorId = 4
    }
};

  await context.Books.AddRangeAsync(books);
 await context.SaveChangesAsync();
 
    }
}