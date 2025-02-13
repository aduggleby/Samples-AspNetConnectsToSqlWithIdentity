using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<YourDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.MapGet("/", async (YourDbContext context) =>
{
    try
    {
        await context.Database.ExecuteSqlRawAsync("SELECT 1");
        return Results.Text($"[{DateTime.UtcNow.ToString()}] Database connection successful.");
    }
    catch (Exception ex)
    {
        return Results.Text($"[{DateTime.UtcNow.ToString()}] Database connection failed: {ex.ToString()}");
    }
});

app.Run(); 