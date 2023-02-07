using System.Runtime.CompilerServices;
using FoodDelivery.Backennd.DAL.Entites;
using FoodDelivery.Backennd.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FoodDelivery.Backennd.DAL.Repositories.Database;

public class ProductRepository : IProductRepository
{
    public async Task AddProduct(Product product)
    {
        await using var context = new DatabaseContext();

        try
        {
            await context.Products!.AddAsync(product);
            await context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<List<Product>> GetProduct()
    {
        await using var context = new DatabaseContext();

        return await context
            .Products
            .ToListAsync();
    }

    public async Task<Product> GetProductByName(string name)
    {
        await using var context = new DatabaseContext();

        return await context
            .Products
            .Where(x => x!.Name == name)
            .FirstOrDefaultAsync();
    }

    public async Task<Product> GetProductById(int id)
    {
        await using var context = new DatabaseContext();

        return await context
            .Products
            .Where(x => x!.ProductId == id)
            .FirstOrDefaultAsync();
    }
    
    public async Task DeleteByProductAsync(Product product)
    {
        await using var context = new DatabaseContext();
        
        try
        {
            context.Products!.Remove(product);
            await context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}