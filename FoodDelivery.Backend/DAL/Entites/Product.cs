using System.Data;

namespace FoodDelivery.Backennd.DAL.Entites;

public class Product
{
    public int ProductId { get; set; } 
    
    public string Name { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }
    public DateTime CreateAt { get; set; } = DateTime.Now;

    public ICollection<ShopingCart> ShoppingCarts;
}