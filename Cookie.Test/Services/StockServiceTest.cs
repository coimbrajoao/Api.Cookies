using Bogus;
using Cookie.Application.DTOs.StockDto;
using Cookie.Application.Exceptions;
using Cookie.Application.Interfaces;
using Cookie.Application.Services;
using Cookie.Domain.Entities;
using Cookie.Domain.Interfaces;
using Moq;
using Xunit;

namespace Cookie.Test.Services;

public class StockServiceTest
{
    private readonly Mock<IStockRepository> _stockRepositoryMock;
    private readonly Mock<IProductRepository> _productRepositoryMock;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly IStockService _stockService;
    private readonly Faker _faker;

    public StockServiceTest()
    {
        _stockRepositoryMock = new Mock<IStockRepository>();
        _productRepositoryMock = new Mock<IProductRepository>();
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _unitOfWorkMock.Setup(r => r.Save()).ReturnsAsync(true);
        _stockService = new StockService(_stockRepositoryMock.Object, _productRepositoryMock.Object,_unitOfWorkMock.Object);
        _faker = new Faker();
    }

    [Fact]
    public async Task CreateStock_WhenProductExists_ShouldCreateStock()
    {
        // Arrange
        var productId = _faker.Random.Int(1, 100);
        var product = new Product("Cookie", "Delicious", "Chocolate", 10.0m);
        var stockRequestDto = new StockRequestDto { ProductId = productId, Quantity = 50 };

        _productRepositoryMock.Setup(r => r.GetByIdAsync(productId))
            .ReturnsAsync(product);

        // Act
        var result = await _stockService.CreateStock(stockRequestDto);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(productId, result.ProductId);
        Assert.Equal(50, result.Quantity);
        Assert.Equal(10.0m, result.Price);
        _stockRepositoryMock.Verify(r => r.AddAsync(It.IsAny<Stock>()), Times.Once);
    }

    [Fact]
    public async Task CreateStock_WhenProductDoesNotExist_ShouldThrowNotFoundException()
    {
        // Arrange
        var productId = _faker.Random.Int(1, 100);
        var stockRequestDto = new StockRequestDto { ProductId = productId, Quantity = 50 };

        _productRepositoryMock.Setup(r => r.GetByIdAsync(productId))
            .ReturnsAsync((Product)null!);

        // Act & Assert
        await Assert.ThrowsAsync<NotFoundException>(() => _stockService.CreateStock(stockRequestDto));
        _stockRepositoryMock.Verify(r => r.AddAsync(It.IsAny<Stock>()), Times.Never);
    }

    [Fact]
    public async Task GetStockById_WhenStockExists_ShouldReturnStockResponse()
    {
        // Arrange
        var stockId = _faker.Random.Int(1, 100);
        var stock = new Stock(1, 10);
        stock.SetUnitPrice(5.0m);

        _stockRepositoryMock.Setup(r => r.GetByIdAsync(stockId))
            .ReturnsAsync(stock);

        // Act
        var result = await _stockService.GetStockById(stockId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(10, result.Quantity);
        Assert.Equal(5.0m, result.Price);
    }

    [Fact]
    public async Task GetStockById_WhenStockDoesNotExist_ShouldThrowNotFoundException()
    {
        // Arrange
        var stockId = _faker.Random.Int(1, 100);

        _stockRepositoryMock.Setup(r => r.GetByIdAsync(stockId))
            .ReturnsAsync((Stock)null!);

        // Act & Assert
        await Assert.ThrowsAsync<NotFoundException>(() => _stockService.GetStockById(stockId));
    }
}