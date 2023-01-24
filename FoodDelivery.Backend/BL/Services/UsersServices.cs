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
    // // Сделать общий список как хранилище данных в памяти
    // public List<UserDto> DataUserDtos = new List<UserDto>();
    // // public DatabaseContext DatabaseContext = new DatabaseContext();
    // public void SignUpUser(UserDto user)
    // {
    //     // Если юзер с такой почтой уже есть, то выводить в консоль ошибку 
    //     // и выходить из метода
    //     
    //     // Если такого юзера нет, то добавлять его в список
    //     DataUserDtos.Add(user);
    //     Console.WriteLine("The user has been added.");
    // }
    //
    // public void SignInUser(UserDto userDto)
    // {
    //     for (var i = 0; i < DataUserDtos.Count; i++)
    //     {
    //         if (DataUserDtos[i].Email == userDto.Email)
    //         {
    //             if (DataUserDtos[i].Password == userDto.Password)
    //             {
    //                 // Если ошибок нет, то выводить в консоль сообщение об успешном входе в приложение
    //                 Console.WriteLine("You have successfully logged into the application.");
    //                 return;
    //             }
    //             else
    //             {
    //                 // Если юзер есть, но пароль неверный, то также выводить в консоль ошибку и выходить из метода
    //
    //                 Console.WriteLine("Invalid password.");
    //                 return;
    //             }
    //         }
    //     }
    //     // Если юзера с такой почтой нет, то выводить в консоль ошибку  и выходить из метода
    //     Console.WriteLine("Such a user does not exist.");
    //
    // }
    //
    // public void ReadList()
    // {
    //     foreach (var dataUserDto in DataUserDtos)
    //     {
    //         Console.WriteLine($"{dataUserDto.Email} {dataUserDto.Password}");
    //     }
    // } 

    private readonly UserRepositories _userRepositories;
    private readonly IRoleRepository _roleRepository;
    public UsersServices()
    {
        _userRepositories = new UserRepositories();
        _roleRepository = new RoleRepository();
    }

    public async Task SignUpUser(UserDto user)
    {
        // var user = _userRepositories.AddUserAsync()
        // await using var context = new DatabaseContext();

        var role = _roleRepository.GetRoleByName(RoleNameConstans.User);

        if (await _userRepositories.GetUserAsync(user.UserName) == null)
        {
            await _userRepositories.AddUserAsync(new User()
            {
                UserName = user.UserName,
                Password = user.Password,
                Roles = new List<Role>
                {
                    await role
                }
            });
            

            // await context.SaveChangesAsync();
        }
        else
        {
            Console.WriteLine("This User already exists!");
        }

    }

    public async Task SignInUser(UserDto user)
    {
        await using var context = new DatabaseContext();

        if(context.Users.Where(u => u.UserName == user.UserName && u.Password == user.Password).FirstOrDefaultAsync() != null)
        {
            Console.WriteLine("Voshle!");
        }
        else
        {
            Console.WriteLine("No!You are loser!");
        }
        
        await context.SaveChangesAsync();
        
        
    }
}