using PlaceOrderConsoleApp.Models;

namespace PlaceOrderConsoleApp.Interfaces;

public interface IProductService
{
    Task<List<Product>> GetProductListAsync();
}
