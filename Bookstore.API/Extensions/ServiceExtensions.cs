using Bookstore.Infrastructure.Data;
using Bookstore.Application.Interfaces;
using Bookstore.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.API.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
       

   services.AddControllers();
   services.AddOpenApi();


services.AddDbContext<BookStoreDbContext>(options =>
{
      options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));




});

services.AddScoped<IUnitOfWork, UnitOfWork>();
services.AddScoped(typeof(IRepository<>),typeof(Repository<>));

services.AddControllers()
       .AddJsonOptions(options =>
       {
           options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
       }
       );

        services.AddScoped<BookRepository>();

        return services;
    }
}