using Bookstore.API.DTOs;
using Bookstore.Application.Interfaces;
using Bookstore.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public BooksController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    // GET /api/books — get all books

   [HttpGet]
   public async Task<IActionResult> GetAllBooksAsync()
  {
    var books = await _unitOfWork.Books.GetAllAsync(); 
   return Ok(books);
  }

    // GET /api/books/{id} — get one book by id

  [HttpGet]
  public async Task<IActionResult> GetBookByIdAsync(int id)
  {
   var book = await _unitOfWork.Books.GetByIdAsync(id);
   if(book is null) return NotFound($"Book With ID:{id} Was Not Found!!");
   return Ok(book);
  }

    // POST /api/books — create a new book


  [HttpPost]
   public async Task<IActionResult> CreateBookAsync(BookCreateDto dto)
{
  if(!ModelState.IsValid) return BadRequest(ModelState);
   var author = await _unitOfWork.Authors.GetByIdAsync(dto.AuthorId);
  if(author is null) return BadRequest($"Author with Id: {dto.AuthorId} not found!!");
var book = new Book 
{
  Title = dto.Title,
  Description = dto.Description,
  Price = dto.Price,
  Quantity = dto.Quantity,
  ISBN = dto.ISBN,
  AuthorId = dto.AuthorId
};

  await _unitOfWork.Books.AddAsync(book);
  await _unitOfWork.SaveAsync();

 return CreatedAtAction(nameof(GetBookByIdAsync), new {id = book.Id}, book);
}
    // PUT /api/books/{id} — update a book

  [HttpPut]

  public async Task<IActionResult> UpdateBookAsync(int id,BookUpdateDto dto)
  {

  if(!ModelState.IsValid) return BadRequest(ModelState);

  var book = await _unitOfWork.Books.GetByIdAsync(id);

  if(book is null) return NotFound($"Book with ID: {id} was not found!!");

  var author = await _unitOfWork.Authors.GetByIdAsync(dto.AuthorId);
  if(author is null) return BadRequest($"Author with Id: {dto.AuthorId} was not found!!");
 book.Title = dto.Title;
 book.Description = dto.Description;
 book.Price = dto.Price;
 book.Quantity = dto.Quantity;
 book.ISBN = dto.ISBN;
 book.AuthorId = dto.AuthorId;
 book.UpdatedAt = DateTime.UtcNow;
  _unitOfWork.Books.Update(book);
  await _unitOfWork.SaveAsync();
return NoContent();
  }

    // DELETE /api/books/{id} — delete a book


  [HttpDelete("{id}")]

  public async Task<IActionResult> DeleteBookAsync(int id)
  {
   var book = await _unitOfWork.Books.GetByIdAsync(id);
  if(book is null) return NotFound($"Book with Id:{id} was not found!!");
   _unitOfWork.Books.Delete(book);
  await _unitOfWork.SaveAsync();
  return NoContent();
  }
}