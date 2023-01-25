﻿namespace FoodDelivery.Backennd.DAL.Entites;

public class Product
{
    public int ProductId { get; set; } 
    
    public string Name { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }

    public ICollection<ShopingCart> ShoppingCarts;
}