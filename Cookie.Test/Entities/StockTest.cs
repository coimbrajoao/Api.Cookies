using Cookie.Domain.Entities;
using Xunit;

namespace Cookie.Test.Entities;

public class StockTest
{
    private const int ValidProductId = 1;
    private const int ValidQuantity = 10;
    private const decimal ValidUnitPrice = 5.50m;

    public class Constructor : StockTest
    {
        [Fact]
        public void Constructor_WhenParametersAreValid_ShouldCreateStock()
        {
            // Act
            var stock = new Stock(ValidProductId, ValidQuantity);

            // Assert
            Assert.Equal(ValidProductId, stock.ProductId);
            Assert.Equal(ValidQuantity, stock.Quantity);
            Assert.NotEqual(default, stock.CreatedAt);
        }

        [Fact]
        public void Constructor_WhenProductIdIsZero_ShouldThrowArgumentException()
        {
            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => new Stock(0, ValidQuantity));
            Assert.Equal("Um produto deve ser informado", exception.Message);
        }
    }

    public class SetUnitPrice : StockTest
    {
        [Fact]
        public void SetUnitPrice_WhenValueIsValid_ShouldSetUnitPrice()
        {
            // Arrange
            var stock = new Stock(ValidProductId, ValidQuantity);

            // Act
            stock.SetUnitPrice(ValidUnitPrice);

            // Assert
            Assert.Equal(ValidUnitPrice, stock.UnitPrice);
        }

        [Fact]
        public void SetUnitPrice_WhenValueIsNegative_ShouldThrowArgumentException()
        {
            // Arrange
            var stock = new Stock(ValidProductId, ValidQuantity);

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => stock.SetUnitPrice(-1));
            Assert.Equal("O valor unitario deve ser maior que zero", exception.Message);
        }
    }

    public class IncreaseStock : StockTest
    {
        [Fact]
        public void IncreaseStock_WhenQuantityIsValid_ShouldIncreaseQuantity()
        {
            // Arrange
            var stock = new Stock(ValidProductId, ValidQuantity);
            var increment = 5;

            // Act
            stock.IncreaseStock(increment);

            // Assert
            Assert.Equal(ValidQuantity + increment, stock.Quantity);
        }

        [Fact]
        public void IncreaseStock_WhenQuantityIsNegative_ShouldThrowArgumentException()
        {
            // Arrange
            var stock = new Stock(ValidProductId, ValidQuantity);

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => stock.IncreaseStock(-1));
            Assert.Equal("A quantidade deve ser maior que zero", exception.Message);
        }
    }

    public class DecreaseStock : StockTest
    {
        [Fact]
        public void DecreaseStock_WhenQuantityIsValid_ShouldDecreaseQuantity()
        {
            // Arrange
            var stock = new Stock(ValidProductId, ValidQuantity);
            var decrement = 5;

            // Act
            stock.DecreaseStock(decrement);

            // Assert
            Assert.Equal(ValidQuantity - decrement, stock.Quantity);
        }

        [Fact]
        public void DecreaseStock_WhenStockIsZero_ShouldThrowArgumentException()
        {
            // Arrange
            var stock = new Stock(ValidProductId, 0);

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => stock.DecreaseStock(5));
            Assert.Equal("A quantidade do produto é igual a zero", exception.Message);
        }

        [Fact]
        public void DecreaseStock_WhenDecrementIsGreaterThanAvailable_ShouldThrowArgumentException()
        {
            // Arrange
            var stock = new Stock(ValidProductId, ValidQuantity);

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => stock.DecreaseStock(ValidQuantity + 1));
            Assert.Equal("O valor e maior que a quantidade disponivel", exception.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        public void DecreaseStock_WhenQuantityIsZeroOrNegative_ShouldThrowArgumentException(int invalidDecrement)
        {
            // Arrange
            var stock = new Stock(ValidProductId, ValidQuantity);

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => stock.DecreaseStock(invalidDecrement));
            Assert.Equal("A quantidade deve ser maior que zero", exception.Message);
        }
    }
}
