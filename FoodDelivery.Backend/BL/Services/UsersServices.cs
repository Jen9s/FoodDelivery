using FoodDelivery.Backennd.BL.DTOs;
using FoodDelivery.Backennd.BL.Interfaces;
using FoodDelivery.Backennd.Common.Constants;
using FoodDelivery.Backennd.DAL;
using FoodDelivery.Backennd.DAL.Entites;
using FoodDelivery.Backennd.DAL.Interfaces;
using FoodDelivery.Backennd.DAL.Repositories.Database;
using Microsoft.EntityFrameworkCore;
using UserRepositories = FoodDelivery.Backennd.DAL.Repositories.Database.UserRepositories;

namespace FoodDelivery.Backennd.BL.Services;

public class UsersServices  : IUsersService
{
    private readonly IUserRepositories _userRepositories;
    private readonly IRoleRepository _roleRepository;
    public UsersServices(
        IUserRepositories? userRepositories = null,
        IRoleRepository? roleRepository = null)
    {
        _userRepositories = userRepositories ?? new UserRepositories();
        _roleRepository = roleRepository ?? new RoleRepository();
    }

    public async Task SignUpUser(UserDto user)
    {

        // if (user != null)
        // {
        //     throw new Exception("User already exists");
        // }
        //
        // var existedUser = await _userRepositories.GetUserAsync(user.UserName);
        // var role = _roleRepository.GetRoleByName(RoleNameConstans.User);
        //
        // if (await _userRepositories.GetUserAsync(user.UserName) == null)
        // {
        //     await _userRepositories.AddUserAsync(new User()
        //     {
        //         UserName = user.UserName,
        //         Password = user.Password,
        //         Roles = new List<Role>
        //         {
        //             await role
        //         }
        //     });
        //     
        //
        //     // await context.SaveChangesAsync();
        // }
        // else
        // {
        //     Console.WriteLine("This User already exists!");
        // }
        
        
        var existedUser = await _userRepositories.GetUserAsync(user.UserName);
        var role = await _roleRepository.GetRoleByName(RoleNameConstans.User);
        
        if (existedUser != null)
        {
            throw new Exception("User already exists");
        }

        await _userRepositories.AddUserAsync(new User()
        {
            UserName = user.UserName,
            Password = user.Password,
            Roles = new List<Role>() { role! }
        });

    }

    public async Task SignInUser(UserDto userDto)
    {

        var existedUser = await _userRepositories.GetUserAsync(userDto.UserName);
        
        if (existedUser is null)
        {
            throw new Exception("User does not exist");
        }

        if (userDto.Password != existedUser.Password)
        {
            throw new Exception("Incorrect password");
        }

        Console.WriteLine("SignIn is successfully!");
    }
}