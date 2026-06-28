using Bookstore.Application.Interfaces;
using Bookstore.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Bookstore.API.DTOs;

namespace Bookstore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorsController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public AuthorsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    // TODO: GET /api/authors — get all authors

    [HttpGet]

    public async Task<IActionResult> GetAllAuthorsAsync()
    {

        var Authors = await _unitOfWork.Authors.GetAllAsync();

        return Ok(Authors);


    }

    // TODO: GET /api/authors/{id} — get one author by id


    [HttpGet("{id:int}" , Name = "GetAuthorById")]

   public async Task<IActionResult> GetAuthorByIdAsync(int id)
{
  if(id == 0) return BadRequest("Enter A Valid ID");

   var Author = await _unitOfWork.Authors.GetByIdAsync(id);


   if(Author is null) return NotFound($"No Author With:{id} Was Found");


   return Ok(Author);



}

    // TODO: POST /api/authors — create a new author

  [HttpPost]

  public async Task<IActionResult> CreateAuthorAsync(AuthorCreateDto dto)
  {

   if(!ModelState.IsValid) return BadRequest(ModelState);
   
    var author = new Author()
   {
     FirstName = dto.FirstName,
     LastName = dto.LastName,
     Biography = dto.Biography
   };
   
   
   await _unitOfWork.Authors.AddAsync(author);

   await _unitOfWork.SaveAsync();


        return CreatedAtRoute("GetAuthorById" ,new {id = author.Id },author);



    }

    // TODO: PUT /api/authors/{id} — update an author


    [HttpPut("{id:int}")]


  public async Task<IActionResult> UpdateAuthorAsync(AuthorUpdateDto dto,int id)
  {


  var author = await _unitOfWork.Authors.GetByIdAsync(id);

  if(author is null) return NotFound($"Author With ID: {id} Was Not Found!!");



  author.FirstName = dto.FirstName;
  author.LastName = dto.LastName;
  author.Biography = dto.Biography;
  author.UpdatedAt = DateTime.UtcNow;

  _unitOfWork.Authors.Update(author);

  await _unitOfWork.SaveAsync();

  return NoContent();

  }

    // TODO: DELETE /api/authors/{id} — delete an author
[HttpDelete("{id:int}")]


  public async Task<IActionResult> DeleteAuthorAsync(int id)
  {

  var author = await _unitOfWork.Authors.GetByIdAsync(id);

  if (author is null) return NotFound($"Author With ID: {id} Was Not Found!!");

   _unitOfWork.Authors.Delete(author);

   await _unitOfWork.SaveAsync();

  return NoContent();



  }
}