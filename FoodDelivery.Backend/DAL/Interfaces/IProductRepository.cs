using FoodDelivery.Backennd.DAL.Entites;

namespace FoodDelivery.Backennd.DAL.Interfaces;

public interface IProductRepository
{
    Task AddProduct(Product product);

    Task<List<Product>> GetProduct();

    Task<Product> GetProductByName(string name);
    
    Task<Product> GetProductById(int id);

    Task DeleteByProductAsync(Product product);
}