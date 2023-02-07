using FoodDelivery.Backennd.BL.DTOs;
using FoodDelivery.Backennd.DAL.Entites;

namespace FoodDelivery.Backennd.BL.Interfaces;

public interface IProductService
{
    Task AddAsync(CreateProductDto createProductDto);

    Task<List<Product>> GetAllProductsAsync();

    Task RemoveProductAsync(int id);
}