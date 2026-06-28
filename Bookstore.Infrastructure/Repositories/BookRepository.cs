using Bookstore.Domain.Entities;
using Bookstore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace Bookstore.Infrastructure.Repositories;


  public class BookRepository : Repository<Book>
{

     public BookRepository(BookStoreDbContext context) : base(context){}

     public override async Task<IEnumerable<Book>> GetAllAsync()
{
  return await _dbSet.Include(b => b.Author).ToListAsync();
}

    public override async Task<Book?> GetByIdAsync(int id)
    {
        return await _dbSet.Include(b => b.Author).FirstOrDefaultAsync(b => b.Id == id);
    }


}