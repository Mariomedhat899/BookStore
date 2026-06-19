 namespace Bookstore.Domain.Entities;

     public class Author : BaseEntity
     {
         

         public string FullName => $"{FirstName} {LastName}";
         
         public string FirstName {get; set;} = string.Empty;

         public string LastName {get; set;} = string.Empty;

         public string? Biography {get; set;} 

         public ICollection<Book> Books {get; set;} = new List<Book>();

 
     }