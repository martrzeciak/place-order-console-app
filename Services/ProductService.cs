using Microsoft.EntityFrameworkCore;
using PlaceOrderConsoleApp.Data;
using PlaceOrderConsoleApp.Interfaces;
using PlaceOrderConsoleApp.Models;

namespace PlaceOrderConsoleApp.Services;

public class ProductService : IProductService
{
    private readonly PlaceOrderDbContext _dbContext;

    public ProductService(PlaceOrderDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Product>> GetProductListAsync()
    {
        return await _dbContext.Products.ToListAsync();
    }
}
