using FluentAssertions;
using FoodDelivery.Backennd.BL.DTOs;
using FoodDelivery.Backennd.BL.Interfaces;
using FoodDelivery.Backennd.BL.Services;
using FoodDelivery.Backennd.DAL.Entites;
using FoodDelivery.Backennd.DAL.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Moq;

namespace FoodDelivery.Tests.Services;

public class ProductServicesTests
{

    private readonly Mock<IProductRepository> _productRepository = new();

    [Test]
    public async Task RemoveProductAsync_WithExistedProduct_ThrowException()
    {
        // Arrange
        var product = new ProductDto()
        {
            Id = 99,
            Name = "Apple",
            Description = "Apple",
            Price = 3
        };
        
        var productService = new ProductService(_productRepository.Object);

        _productRepository
            .Setup(p => p.GetProductByName(It.IsAny<string>()))
            .ReturnsAsync((Product)null!);

        // Act/Assert

        await productService
            .Invoking(p => p.RemoveProductAsync(product.Id))
            .Should()
            .ThrowAsync<Exception>()
            .WithMessage("Product already exists");

    }
    
    // [Test]
    // public async Task SignUpUserAsync_WithUnexistedUser_ShouldCallCallAddUserOnce()
    // {
    //     // Arrange
    //     var product = new CreateProductDto()
    //     {
    //         Name = "Apple",
    //         Description = "Apple",
    //         Price = 3
    //     };
    //     
    //     var productService = new ProductService(_productRepository.Object);
    //
    //     _productRepository
    //         .Setup(p => p.GetProductByName(It.IsAny<string>()))
    //         .ReturnsAsync((Product)null!);
    //
    //     // Act/Assert
    //
    //     await productService
    //         .Invoking(p => p.AddAsync(product))
    //         .Should()
    //         .ThrowAsync<Exception>()
    //         .WithMessage("Product already exists");
    // }
}