using FoodDelivery.Backennd.BL.DTOs;

namespace FoodDelivery.Backennd.BL.Interfaces;

public interface IUsersService
{
    void SignUpUser(UserDto userDto);

    void SignInUser(UserDto userDto);

    void ReadList();
}