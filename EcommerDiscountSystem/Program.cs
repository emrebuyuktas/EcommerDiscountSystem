using System.Reflection;
using EcommerDiscountSystem;
using EcommerDiscountSystem.Middlewares;
using EcommerDiscountSystem.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddServices(builder.Configuration);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
dbContext.Database.Migrate();
if(!dbContext.Products.Any())
{
    

    var technology =new Category("technology");
    var home = new Category("home");
    var selfCare = new Category("selfCare");
    
    await dbContext.Categories.AddAsync(technology);
    await dbContext.Categories.AddAsync(home);
    await dbContext.Categories.AddAsync(selfCare);
    await dbContext.SaveChangesAsync();
    var products = new List<Product>
    {
        new Product("phone", 100, technology),
        new Product("rubber", 200, home),
        new Product("toothbrush", 300, selfCare),
    };
    
    await dbContext.Products.AddRangeAsync(products);
    await dbContext.SaveChangesAsync();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<ErrorHandlerMiddleware>();
app.MapControllers();

app.Run();