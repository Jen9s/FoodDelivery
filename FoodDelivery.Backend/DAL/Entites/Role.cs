﻿namespace FoodDelivery.Backennd.DAL.Entites;

public class Role
{
    public int RoleId { get; set; }
    public string Name { get; set; }
    public ICollection<User> Users { get; set; }
}