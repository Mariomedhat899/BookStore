namespace Bookstore.API.DTOs;

public class AuthorUpdateDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? Biography { get; set; }
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}