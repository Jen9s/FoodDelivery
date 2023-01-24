using FoodDelivery.Backennd.Common.Constants;
using FoodDelivery.Backennd.DAL.Entites;
using Microsoft.EntityFrameworkCore;

namespace FoodDelivery.Backennd.DAL;

public class DataBaseContextSeed
{
    public static async Task SeedDefoltRolesAsync()
    {
        await using var context = new DatabaseContext();

        if (await context.Roles!.Where(t => t.Name == RoleNameConstans.Manager).FirstOrDefaultAsync() is null)
        {
            await context.Roles!.AddAsync(new Role
            {
                Name =  RoleNameConstans.Manager
            });
        }
        
        if (await context.Roles!.Where(t => t.Name ==  RoleNameConstans.User).FirstOrDefaultAsync() is null)
        {
            await context.Roles!.AddAsync(new Role
            {
                Name =  RoleNameConstans.User
            });
        }
        
        var managerRole = context.Roles.FirstOrDefault(t => t.Name == RoleNameConstans.Manager);
        var userRole = context.Roles.FirstOrDefault(t => t.Name == RoleNameConstans.User);

        var manager = new User()
        {
            UserName = "Manager",
            Password = "Manager",
            Roles = new List<Role> { managerRole! }
        };
        
        var user = new User()
        {
            UserName = "User",
            Password = "User",
            Roles = new List<Role> { userRole! }
        };

        if (await context.Users!.Where(t => t.UserName == manager.UserName).FirstOrDefaultAsync() is null)
        {
            await context.Users!.AddAsync(manager);
        }
        
        if (await context.Users!.Where(t => t.UserName == user.UserName).FirstOrDefaultAsync() is null)
        {
            await context.Users!.AddAsync(user);
        }

        await context.SaveChangesAsync();
    }
}