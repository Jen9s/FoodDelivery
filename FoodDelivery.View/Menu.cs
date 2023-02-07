using FoodDelivery.Backennd.BL.DTOs;
using FoodDelivery.Backennd.BL.Interfaces;
using FoodDelivery.Backennd.BL.Services;

namespace FoodDelivery.View;

public class Menu
{
    private readonly IUsersService _usersService;
    private readonly IProductService _productService;
    
    public Menu()
    {
        _usersService = new UsersServices();
        _productService = new ProductService();
    }
    
    public async Task DisplayMainMenu()
    {

        while (true)
        for(int i = 0;i < 2;i++)
        {   
            Console.WriteLine("If you want to exit enter 0.");
            Console.WriteLine("If you want to register enter 1.");
            Console.WriteLine("If you want to sign up enter 2.");
            Console.WriteLine("Create Products 3.");
            Console.WriteLine("Get all Products 4.");
            Console.WriteLine("Remove products 5");
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
                    Console.WriteLine("Enter you password:");
                    string password = Console.ReadLine();
                    UserDto userDto = new UserDto
                        { UserName = name, Password = password };
                    _usersService.SignUpUser(userDto);
                    break;
                }
                case "2":
                {
                    Console.WriteLine("Enter your Name:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter you password:");
                    string password = Console.ReadLine();
                    UserDto userDto = new UserDto() { UserName = name, Password = password };
                    _usersService.SignInUser(userDto);
                    break;
                }
                case "3":
                {
                    Console.WriteLine("Enter  Name:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter description:");
                    var description = Console.ReadLine();
                    Console.WriteLine("Enter price:");
                    var tryParse = double.TryParse(Console.ReadLine(), out var price);

                    if (tryParse)
                    {
                        _productService.AddAsync(new CreateProductDto()
                        {
                            Name = name,
                            Description = description,
                            Price = price
                        });
                    }
                    break;
                }
                case "4":
                {
                    var products = await _productService.GetAllProductsAsync();
                    
                    foreach (var product in products)
                    {
                        Console.WriteLine("\nProduct\n");
                        Console.WriteLine($"Id: {product.ProductId}");
                        Console.WriteLine($"Name: {product.Name}");
                        Console.WriteLine($"Descriptions: {product.Description}");
                        Console.WriteLine($"Price: {product.Price}");
                        Console.WriteLine($"{product.CreateAt}");
                    }
                    
                    break;
                }
                case "5":
                {
                    Console.WriteLine($"Enter product Id: ");
                    var tryParse = int.TryParse(Console.ReadLine(), out var id);

                    if (tryParse)
                    {
                        await _productService.RemoveProductAsync(id);
                    }
                    break;
                }
            }
        }
        // Добавить два пункта меню для регистрации и логина
        // Добавить два подменю для введения данных пользователя
        // После введения данных вызывать соответствующие методы из IUsersService
        // Console.WriteLine("1. Sign un user");
        //
        // _usersService.SignUpUser(new UserDto() 
        //     { Email = "f", FirstName = "Artem", LastName = "Petrov" });
    }
}