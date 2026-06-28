using Bookstore.API.DTOs;
using Bookstore.Application.Interfaces;
using Bookstore.Domain.Entities;
using Bookstore.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace Bookstore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly BookRepository _bookRepo;

    public BooksController(IUnitOfWork unitOfWork, BookRepository bookRepo)
    {
        _unitOfWork = unitOfWork;
        _bookRepo = bookRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBooksAsync()
    {
        var books = await _bookRepo.GetAllAsync();
        return Ok(books);
    }

    [HttpGet("{id:int}", Name = "GetBookById")]
    public async Task<IActionResult> GetBookByIdAsync(int id)
    {
        var book = await _bookRepo.GetByIdAsync(id);
        if (book is null) return NotFound($"Book with ID: {id} was not found!!");
        return Ok(book);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBookAsync(BookCreateDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var author = await _unitOfWork.Authors.GetByIdAsync(dto.AuthorId);
        if (author is null) return BadRequest($"Author with ID: {dto.AuthorId} not found!!");

        var book = new Book
        {
            Title = dto.Title,
            Description = dto.Description,
            Price = dto.Price,
            Quantity = dto.Quantity,
            ISBN = dto.ISBN,
            AuthorId = dto.AuthorId
        };

        await _bookRepo.AddAsync(book);
        await _unitOfWork.SaveAsync();

        return CreatedAtRoute("GetBookById", new { id = book.Id }, book);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateBookAsync(int id, BookUpdateDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var book = await _bookRepo.GetByIdAsync(id);
        if (book is null) return NotFound($"Book with ID: {id} was not found!!");

        var author = await _unitOfWork.Authors.GetByIdAsync(dto.AuthorId);
        if (author is null) return BadRequest($"Author with ID: {dto.AuthorId} not found!!");

        book.Title = dto.Title;
        book.Description = dto.Description;
        book.Price = dto.Price;
        book.Quantity = dto.Quantity;
        book.ISBN = dto.ISBN;
        book.AuthorId = dto.AuthorId;
        book.UpdatedAt = DateTime.UtcNow;

        _bookRepo.Update(book);
        await _unitOfWork.SaveAsync();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteBookAsync(int id)
    {
        var book = await _bookRepo.GetByIdAsync(id);
        if (book is null) return NotFound($"Book with ID: {id} was not found!!");

        _bookRepo.Delete(book);
        await _unitOfWork.SaveAsync();

        return NoContent();
    }

    [HttpPost("{id:int}/cover")]
    public async Task<IActionResult> UploadCoverImage(int id, IFormFile file)
    {
        if (id <= 0) 
            return BadRequest($"Enter a valid ID!!");

        if (file == null || file.Length == 0)
            return BadRequest("No file uploaded!!");

        if (!file.ContentType.StartsWith("image/"))
            return BadRequest("The uploaded file is not an image!!");

        var book = await _bookRepo.GetByIdAsync(id);
        if (book is null)
            return NotFound($"Book with ID: {id} was not found!!");

        var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "covers" , fileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        book.CoverImagePath = $"/covers/{fileName}";
        _bookRepo.Update(book);

        await _unitOfWork.SaveAsync();

        return Ok(new { coverImagePath = book.CoverImagePath });
 

    }
}
