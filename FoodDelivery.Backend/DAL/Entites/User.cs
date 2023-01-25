namespace FoodDelivery.Backennd.DAL.Entites;

public class User
{
    public int UserId { get; set; }
    public string Password { get; set; }
    public string UserName { get; set; }
    
    public ICollection<Role> Roles { get; set; }
    
    public ICollection<ShopingCart> ShoppingCarts { get; set; }
}