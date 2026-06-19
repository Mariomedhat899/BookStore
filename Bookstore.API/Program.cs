using Bookstore.Infrastructure.Data;
using Bookstore.Application.Interfaces;
using Bookstore.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


 builder.Services.AddDbContext<BookStoreDbContext>(options => 
{
      options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));




});

 builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
 builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>));


var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}








app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
