using FoodDelivery.Backennd.DAL.Entites;

namespace FoodDelivery.Backennd.DAL.Interfaces;

public interface IUserRepositories
{ 
    Task AddUserAsync(User user);
    Task<User?> GetUserAsync(string name);
}