using FluentAssertions;
using FoodDelivery.Backennd.BL.DTOs;
using FoodDelivery.Backennd.BL.Services;
using FoodDelivery.Backennd.DAL.Entites;
using FoodDelivery.Backennd.DAL.Interfaces;
using Moq;

namespace FoodDelivery.Tests.Services;

public class UserServicesTests
{
    private readonly Mock<IUserRepositories> _userRepositoryStub = new();
    private readonly Mock<IRoleRepository> _roleRepositoryStub = new();

    [Test]
    public async Task SignUpUserAsync_WithExistedUser_ThrowException()
    {
        // Arrange
        var userDto = new UserDto()
        {
            UserName = "TestUser",
            Password = "TestPassword"
        };

        var usersService = new UsersServices(_userRepositoryStub.Object, _roleRepositoryStub.Object);

        _userRepositoryStub
            .Setup(t => t.GetUserAsync(It.IsAny<string>()))
            .ReturnsAsync(new User());

        // Act/Assert
        await usersService
            .Invoking(t => t.SignUpUser(userDto))
            .Should()
            .ThrowAsync<Exception>()
            .WithMessage("User already exists");
    }

    [Test]
    public async Task SignUpUserAsync_WithUnexistedUser_ShouldCallCallAddUserOnce()
    {
        // Arrange
        var userDto = new UserDto()
        {
            UserName = "TestUser",
            Password = "TestPassword"
        };

        var role = new Role()
        {
            Name = "User",
            RoleId = 4
        };
        

        var usersService = new UsersServices(_userRepositoryStub.Object, _roleRepositoryStub.Object);

        _userRepositoryStub
            .Setup(t => t.GetUserAsync(It.IsAny<string>()))
            .ReturnsAsync((User)null!);

        _roleRepositoryStub
            .Setup(t => t.GetRoleByName(It.IsAny<string>()))
            .ReturnsAsync(role);
        
        // Act
        await usersService.SignUpUser(userDto);

        // Assert
        _userRepositoryStub.Verify(t => t.AddUserAsync(It.IsAny<User>()), Times.Once);
    }
    
    [Test]
    public async Task SignInUserAsync_WithUnexistedUser_ThrowException()
    {
        // Arrange
        var userDto = new UserDto()
        {
            UserName = "TestUser",
            Password = "TestPassword"
        };

        var usersService = new UsersServices(_userRepositoryStub.Object, _roleRepositoryStub.Object);

        _userRepositoryStub
            .Setup(t => t.GetUserAsync(It.IsAny<string>()))
            .ReturnsAsync((User)null!);

        // Act/Assert
        await usersService
            .Invoking(t => t.SignInUser(userDto))
            .Should()
            .ThrowAsync<Exception>()
            .WithMessage("User does not exist");
    }
    
    [Test]
    public async Task SignInUserAsync_WithIncorrectPassword_ThrowException()
    {
        // Arrange
        var userDto = new UserDto()
        {
            UserName = "TestUser",
            Password = "TestPassword"
        };

        var usersService = new UsersServices(_userRepositoryStub.Object, _roleRepositoryStub.Object);

        _userRepositoryStub
            .Setup(t => t.GetUserAsync(It.IsAny<string>()))
            .ReturnsAsync(new User()
            {
                Password = "WrongPassword"
            });

        // Act/Assert
        await usersService
            .Invoking(t => t.SignInUser(userDto))
            .Should()
            .ThrowAsync<Exception>()
            .WithMessage("Incorrect password");
    }
    
}