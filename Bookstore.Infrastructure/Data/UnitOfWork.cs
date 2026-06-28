using Bookstore.Application.Interfaces;
using Bookstore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Bookstore.Infrastructure.Repositories;

namespace Bookstore.Infrastructure.Data;

public class UnitOfWork : IUnitOfWork
{

private readonly BookStoreDbContext _context;
private IRepository<Author>? _authors;
private IRepository<Book>? _books;

public UnitOfWork(BookStoreDbContext context)
{

   _context = context;

}


public IRepository<Author> Authors => _authors ??= new Repository<Author>(_context);

public IRepository<Book> Books => _books ??= new Repository<Book>(_context);


   public async Task<int> SaveAsync()
{

  return await _context.SaveChangesAsync();
}


public void Dispose()
{
   _context.Dispose();
}


}