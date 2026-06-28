namespace Bookstore.API.Extensions;

public static class MiddlewareExtensions
{
    public static WebApplication ConfigureMiddleware(this WebApplication app)
    {
       

        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseAuthorization();

        app.MapControllers();


        return app;
    }
}