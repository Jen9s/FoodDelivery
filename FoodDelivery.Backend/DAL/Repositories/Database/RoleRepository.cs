using FoodDelivery.Backennd.DAL.Entites;
using FoodDelivery.Backennd.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FoodDelivery.Backennd.DAL.Repositories.Database;

public class RoleRepository : IRoleRepository
{
    public Task<Role> GetRoleByName(string name)
    {
        using var context = new DatabaseContext();

        return context.Roles!.Where(t => t.Name == name).FirstOrDefaultAsync();
    }
}