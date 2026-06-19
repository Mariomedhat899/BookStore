# 📚 Bookstore API

A RESTful bookstore API built with **Clean Architecture** and **.NET 10**, featuring a custom Generic Repository and Unit of Work pattern implemented manually on top of EF Core.

## 🏗️ Architecture

This project follows **Clean Architecture** principles with 4 layers:
**Dependency direction:** API → Application ← Infrastructure → Domain

## ✨ Features

- ✅ Full CRUD for Authors and Books
- ✅ Generic Repository Pattern (`IRepository<T>`)
- ✅ Unit of Work pattern (`IUnitOfWork`)
- ✅ Entity Framework Core with explicit Fluent API configuration
- ✅ DTOs for API input/output (separation of concerns)
- ✅ SQL Server LocalDB database
- ✅ ASP.NET Core Web API with dependency injection

## 🛠️ Tech Stack

| Technology | Version |
|-----------|---------|
| .NET | 10.0 |
| ASP.NET Core Web API | 10.0 |
| Entity Framework Core | 8.0 |
| SQL Server LocalDB | 2022 |
| C# | 10.0 |

## 📋 API Endpoints

### Authors

| Method | Endpoint | Description |
|--------|----------|-------------|
| `GET` | `/api/authors` | Get all authors |
| `GET` | `/api/authors/{id}` | Get author by ID |
| `POST` | `/api/authors` | Create a new author |
| `PUT` | `/api/authors/{id}` | Update an author |
| `DELETE` | `/api/authors/{id}` | Delete an author |

### Books

| Method | Endpoint | Description |
|--------|----------|-------------|
| `GET` | `/api/books` | Get all books |
| `GET` | `/api/books/{id}` | Get book by ID |
| `POST` | `/api/books` | Create a new book |
| `PUT` | `/api/books/{id}` | Update a book |
| `DELETE` | `/api/books/{id}` | Delete a book |

## 🚀 Getting Started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [SQL Server LocalDB](https://learn.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb) (usually included with Visual Studio)
- [Git](https://git-scm.com/)

### Installation

```bash
# Clone the repository
git clone <https://github.com/Mariomedhat899/BookStore.git>
cd BookStore

# Restore dependencies
dotnet restore

# Update connection string (optional)
# Edit Bookstore.API/appsettings.json to point to your database

# Apply database migrations
dotnet ef database update --project Bookstore.Infrastructure --startup-project Bookstore.API

# Run the API
dotnet run --project Bookstore.API

he API will be available at https://localhost:5001 or http://localhost:5000.

📁 Project Structure
BookStore/
├── Bookstore.Domain/
│   └── Entities/
│       ├── BaseEntity.cs
│       ├── Author.cs
│       └── Book.cs
├── Bookstore.Application/
│   └── Interfaces/
│       ├── IRepository.cs
│       └── IUnitOfWork.cs
├── Bookstore.Infrastructure/
│   ├── Data/
│   │   ├── BookStoreDbContext.cs
│   │   ├── BookstoreDbContextFactory.cs
│   │   └── UnitOfWork.cs
│   ├── Repositories/
│   │   └── Repository.cs
│   └── Migrations/
└── Bookstore.API/
    ├── Controllers/
    │   ├── AuthorsController.cs
    │   └── BooksController.cs
    ├── DTOs/
    │   ├── AuthorCreateDto.cs
    │   ├── AuthorUpdateDto.cs
    │   ├── BookCreateDto.cs
    │   └── BookUpdateDto.cs
    └── Program.cs


## 🔑 Key Design Decisions

- **Explicit Fluent API** over convention-based mapping — for learning purposes and full control
- **DTOs in API layer** — keeps domain entities pure, controls what the API exposes
- **Custom Repository + Unit of Work** — built manually to understand the patterns deeply (EF Core already provides these abstractions)
- **Book cover images** stored in external folder (not in database) — planned feature

## 📝 License

This project is for learning purposes. No license applied.

---

Built with ❤️ by Mario Medhat as a .NET learning project.
