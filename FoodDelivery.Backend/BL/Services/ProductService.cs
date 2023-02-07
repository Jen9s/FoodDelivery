using FoodDelivery.Backennd.BL.DTOs;
using FoodDelivery.Backennd.BL.Interfaces;
using FoodDelivery.Backennd.DAL.Entites;
using FoodDelivery.Backennd.DAL.Interfaces;
using FoodDelivery.Backennd.DAL.Repositories.Database;

namespace FoodDelivery.Backennd.BL.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService()
    {
        _productRepository = new ProductRepository();
    }

    public ProductService(IProductRepository? productRepository = null)
    {
        _productRepository = productRepository ?? new ProductRepository();
    }

    public async Task AddAsync(CreateProductDto createProductDto)
    {
        var existedProduct = await _productRepository
            .GetProductByName(createProductDto.Name);

        if (existedProduct is not null)
        {
            Console.WriteLine("Product already exists!");
        }

        await _productRepository.AddProduct(new Product()
        {
            Name = createProductDto.Name,
            Description = createProductDto.Description,
            Price = createProductDto.Price
        });
    }

    public async Task<List<Product>> GetAllProductsAsync()
    {
        return await _productRepository.GetProduct();
    }

    public async Task RemoveProductAsync(int id)
    {
        var product = await _productRepository.GetProductById(id);

        if (product is null)
        {
            throw new Exception("Product already exists");
        }

        await _productRepository.DeleteByProductAsync(product);
    }
}















