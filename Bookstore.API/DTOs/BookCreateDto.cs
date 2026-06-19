namespace Bookstore.API.DTOs;

public class BookCreateDto
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string ISBN { get; set; } = string.Empty;
    public int AuthorId { get; set; }
}