using Bookstore.Infrastructure.Data;
using Bookstore.Application.Interfaces;
using Bookstore.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Bookstore.API.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddApplicationServices(builder.Configuration);


var app = builder.Build();


var scope = app.Services.CreateScope();

var context = scope.ServiceProvider.GetRequiredService<BookStoreDbContext>();

await DbInitializer.InitializeAsync(context);

app.ConfigureMiddleware();

app.Run();
