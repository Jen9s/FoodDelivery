using FoodDelivery.Backennd.BL.DTOs;

namespace FoodDelivery.Backennd.BL.Interfaces;

public interface IUsersService
{
    Task SignUpUser(UserDto userDto);

    Task SignInUser(UserDto userDto);
    
}