using FoodDelivery.Backennd.BL.DTOs;
using FoodDelivery.Backennd.BL.Interfaces;
using FoodDelivery.Backennd.BL.Services;

namespace FoodDelivery.View;

public class Menu
{
    private readonly IUsersService _usersService;
    
    public Menu()
    {
        _usersService = new UsersServices();
    }
    
    public void DisplayMainMenu()
    {
        while (true)
        {   
            Console.WriteLine("If you want to exit enter 0.");
            Console.WriteLine("If you want to register enter 1.");
            Console.WriteLine("If you want to sign up enter 2.");
            string? answer = Console.ReadLine();
            switch (answer)
            {
                case "0":
                {
                    Console.WriteLine("Goodbye!");
                    return;
                }
                case "1":
                {
                    Console.WriteLine("Enter your Name:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter your LastName:");
                    string lastName = Console.ReadLine();
                    Console.WriteLine("Enter your Email:");
                    string email = Console.ReadLine();
                    Console.WriteLine("Enter you password:");
                    string password = Console.ReadLine();
                    UserDto userDto = new UserDto
                        { Email = email, FirstName = name, LastName = lastName, Password = password };
                    _usersService.SignUpUser(userDto);
                    break;
                }
                case "2":
                {
                    Console.WriteLine("Enter your Email:");
                    string email = Console.ReadLine();
                    Console.WriteLine("Enter you password:");
                    string password = Console.ReadLine();
                    UserDto userDto = new UserDto() { Email = email, Password = password };
                    _usersService.SignInUser(userDto);
                    break;
                }
                case "3":
                {
                    _usersService.ReadList();
                    break;
                }
            }
        }
        // Добавить два пункта меню для регистрации и логина
        // Добавить два подменю для введения данных пользователя
        // После введения данных вызывать соответствующие методы из IUsersService
        Console.WriteLine("1. Sign un user");
        
        _usersService.SignUpUser(new UserDto() 
            { Email = "f", FirstName = "Artem", LastName = "Petrov" });
    }
}