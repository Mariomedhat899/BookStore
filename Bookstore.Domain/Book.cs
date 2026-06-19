 namespace Bookstore.Domain.Entities;

     public class Book : BaseEntity
{

public string Title {get; set;} = string.Empty;

public string Description {get; set;} = string.Empty;

public decimal Price {get; set;}

public int Quantity {get; set;}

public string ISBN {get; set;} = string.Empty;

public string? CoverImagePath {get; set;}

public int AuthorId {get; set;}

public Author Author {get; set;} = null!;








}