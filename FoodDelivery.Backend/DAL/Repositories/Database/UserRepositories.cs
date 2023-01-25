using FoodDelivery.Backennd.BL.Interfaces;
using FoodDelivery.Backennd.DAL.Entites;
using Microsoft.EntityFrameworkCore;

namespace FoodDelivery.Backennd.DAL.Repositories.Database;

public class UserRepositories : Interfaces.IUserRepositories
{
    public async Task AddUserAsync(User user)
    {
        using var context = new DatabaseContext();

        context.Users.Attach(user);
        context.Entry(user).State = EntityState.Added;
        
        await context.Users!.AddAsync(user);
        context.SaveChanges();
    }

    public async Task<User> GetUserAsync(string name)
    {
        using var context = new DatabaseContext();
        var user  = await context.Users.Where(u => u.UserName == name).FirstOrDefaultAsync();
        return user;
    }

}
