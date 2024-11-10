
using Application.Common.Interfaces.Persistence;
using Application.Features.Products.Commands;
using Domain.Entities;
using Moq;

namespace UnitTest.Application.Features.Products;

public class CreateProductCommandHandlerTests
{
    private readonly Mock<IUnitOfWork<int>> _mockUnitOfWork;
    private readonly CreateProductCommandHandler _handler;

    public CreateProductCommandHandlerTests()
    {
        _mockUnitOfWork = new Mock<IUnitOfWork<int>>();
        _handler = new CreateProductCommandHandler(_mockUnitOfWork.Object);
    }

    [Fact]
    public async Task Handle_ShouldReturnProductId_WhenProductIsCreated()
    {
        // Arrange
        var command = new CreateProductCommand
        {
            ProductName = "Test Product 12345",
            RegularPrice = 100.0,
            SalePrice = 80.0,
            Description = "A test product description"
        };
        var cancellationToken = new CancellationToken();

        var product = new Product
        {
            Id = 1,
            Name = command.ProductName,
            RegularPrice = command.RegularPrice,
            SalePrice = command.SalePrice,
            Description = command.Description
        };


        _mockUnitOfWork.Setup(u => u.Repository<Product>().AddAsync(It.IsAny<Product>()))
                       .Callback<Product>(p => p.Id = product.Id)
                       .Returns(Task.FromResult(product));

        // Act
        var result = await _handler.Handle(command, cancellationToken);

        // Assert
        Assert.True(result.Succeeded);
        Assert.Equal(product.Id, result.Data);

        _mockUnitOfWork.Verify(u => u.Repository<Product>().AddAsync(It.IsAny<Product>()), Times.Once);

        _mockUnitOfWork.Verify(u => u.Commit(cancellationToken), Times.Once);
    }
}
