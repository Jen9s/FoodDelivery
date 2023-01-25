namespace FoodDelivery.Backennd.DAL.Entites;

public class ShopingCart
{
    public int ShopingCartId { get; set; }
    public Product Product { get; set; }
    
    public  int UserId { get; set; }
    public User User { get; set; }

}