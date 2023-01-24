using FoodDelivery.Backennd.DAL.Entites;

namespace FoodDelivery.Backennd.DAL.Interfaces;

public interface IRoleRepository
{
    public Task<Role> GetRoleByName(string name);
}