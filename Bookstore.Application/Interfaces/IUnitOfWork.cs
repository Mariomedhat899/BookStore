namespace Bookstore.Application.Interfaces;
 using Bookstore.Domain.Entities;

     public interface IUnitOfWork : IDisposable
     {
         IRepository<Author> Authors { get; }
         IRepository<Book> Books { get; }
         Task<int> SaveAsync();
     }