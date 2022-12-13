using FoodDelivery.Backennd.BL.DTOs;
using FoodDelivery.Backennd.BL.Interfaces;

namespace FoodDelivery.Backennd.BL.Services;

public class UsersServices : IUsersService
{
    // Сделать общий список как хранилище данных в памяти
    public List<UserDto> DataUserDtos = new List<UserDto>();
    public void SignUpUser(UserDto user)
    {
        // Если юзер с такой почтой уже есть, то выводить в консоль ошибку 
        // и выходить из метода
        for (var i = 0; i < DataUserDtos.Count; i++)
        {
            if (DataUserDtos[i].Email == user.Email)
            {
                Console.WriteLine("User with this email already exits!");
                return;
            }
        }
        // Если такого юзера нет, то добавлять его в список
        DataUserDtos.Add(user);
        Console.WriteLine("The user has been added.");
    }

    public void SignInUser(UserDto userDto)
    {
        for (var i = 0; i < DataUserDtos.Count; i++)
        {
            if (DataUserDtos[i].Email == userDto.Email)
            {
                if (DataUserDtos[i].Password == userDto.Password)
                {
                    // Если ошибок нет, то выводить в консоль сообщение об успешном входе в приложение
                    Console.WriteLine("You have successfully logged into the application.");
                    return;
                }
                else
                {
                    // Если юзер есть, но пароль неверный, то также выводить в консоль ошибку и выходить из метода

                    Console.WriteLine("Invalid password.");
                    return;
                }
            }
        }
        // Если юзера с такой почтой нет, то выводить в консоль ошибку  и выходить из метода
        Console.WriteLine("Such a user does not exist.");
 
    }

    public void ReadList()
    {
        foreach (var dataUserDto in DataUserDtos)
        {
            Console.WriteLine($"{dataUserDto.Email} {dataUserDto.Password}");
        }
    } 
}