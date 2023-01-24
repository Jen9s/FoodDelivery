using FoodDelivery.Backennd.DAL.Entites;

namespace FoodDelivery.Backennd.DAL.Interfaces;

public interface UserRepositories
{ 
    Task AddUserAsync(User user);
}