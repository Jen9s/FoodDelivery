﻿namespace FoodDelivery.Backennd.BL.DTOs;

public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }
    
    public DateTime CreateAt { get; set; } = DateTime.Now;
}