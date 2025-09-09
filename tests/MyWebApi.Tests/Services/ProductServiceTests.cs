using Xunit;
using Moq;
using MyWebApi.Models;
using Microsoft.EntityFrameworkCore;
using MyWebApi.Data;

public class ProductServiceTests
{
    [Fact]
    public async Task GetProducts_ReturnsProducts()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb").Options;

        using var context = new AppDbContext(options);
        context.Products.Add(new Product { Id = 1, Name = "Test", Price = 10 });
        context.SaveChanges();

        var products = await context.Products.ToListAsync();
        Assert.Single(products);
    }
}
