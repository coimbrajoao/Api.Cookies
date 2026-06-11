using Cookie.Domain.Entities;

namespace Cookie.Test.Entities;

public class ProductTest
{
    private const string Name = "triplo";
    private const string Description = "triplo chocolate";
    const decimal Price = 15;
    const string FlavorTest = "Nutela";
    
    public class Constructor : ProductTest
    {
        [Fact]
        public void constructor_GivenAllParams_ShouldSetProperties()
        {
            
            //act
            var product = new Product(Name, Description, FlavorTest, Price);

            //assert

            Assert.Equal(Name, product.Name);
            Assert.Equal(Description, product.Description);
            Assert.Equal(Price, product.Price);
            Assert.Equal(FlavorTest, product.Flavor);
            Assert.NotNull(product.Stocks);
        }

        [Theory]
        [InlineData("", "Descrição", "Sabor", 10)]
        [InlineData("Nome", "", "Sabor", 10)]
        [InlineData("nome", "Descrição", "", 10)]
        [InlineData("nome", "Descrição", "Sabor", 0)]
        [InlineData("nome", "Descrição", "Sabor", -5)]
        public void Constructor_GivenInvalidParameters_ShouldThrowArgumentException(
            string name,
            string description,
            string flavor,
            decimal price)
        {
            Assert.Throws<ArgumentException>(() => new Product(name, description, flavor, price));
        }
    }
    
    public class UpdateName: ProductTest
    {
        
        [Theory]
        [InlineData("Kinder")]
        [InlineData(Name)]
        public void UpdateName_GivenValidParameters_ShouldSetProperties(
            string invalidName)
        {
            
            //act
            var product = new Product(Name, Description, FlavorTest, Price);
                
            product.UpdateName(invalidName);
            
            //Assert    
            Assert.Equal(invalidName, product.Name);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData(" ")]
        public void UpdateName_GivenInvalidParameters_ShouldThrowArgumentException(
            string nameExpected)
        {
            //arrange
            var product = new Product(Name, Description, FlavorTest, Price);
        
            //assert
            Assert.Throws<ArgumentException>(() => product.UpdateName(nameExpected));
        }
    }

    public class UpdateDescription : ProductTest
    {
        [Theory]
        [InlineData("nova descrição")]
        [InlineData(Description)]
        public void UpdateDescription_GivenValidParameters_ShouldSetProperties(string descriptionExpected)
        {
            //arrange
            var product = new Product(Name, Description, FlavorTest, Price);
            
            //act
            product.UpdateDescription(descriptionExpected);
            
            //assert
            Assert.Equal(descriptionExpected, product.Description);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData(" ")]
        public void UpdateDescription_GivenInvalidParameters_ShouldThrowArgumentException(string invalidDescription)
        {
            //arrange
            var product = new Product(Name, Description, FlavorTest, Price);
         
            //act -> assert
            Assert.Throws<ArgumentException>(() => product.UpdateDescription(invalidDescription));
        }
    }
    
    public class Flavor: ProductTest
    {
        [Theory]
        [InlineData("novo sabor")]
        [InlineData(FlavorTest)]
        public void UpdateFlavor_GivenValidParameters_ShouldSetProperties(string flavorExpected)
        {
            var product = new Product(Name, Description, FlavorTest, Price);
            product.UpdateFlavor(flavorExpected);
            Assert.Equal(flavorExpected, product.Flavor);
        }
        
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData(" ")]
        public void updateFlavor_GivenInvalidParameters_ShouldThrowArgumentException(string invalidFlavor)
        {
            var product = new Product(Name, Description, FlavorTest, Price);
            Assert.Throws<ArgumentException>(() => product.UpdateFlavor(invalidFlavor));
        }
    }

    public class SetPrice : ProductTest
    {
        [Theory]
        [InlineData(10)]
        public void SetPrice_GivenValidParameters_ShouldSetProperties(decimal priceExpected)
        {
            var product = new Product(Name, Description, FlavorTest, Price);
            product.SetPrice(priceExpected);
            Assert.Equal(priceExpected, product.Price);
        }

        [Fact]
        public void SetPrice_GivenSamePrice_ShouldMaintainCurrentPrice()
        {
            var product = new Product(Name, Description, FlavorTest, Price);
            product.SetPrice(Price);
            Assert.Equal(Price, product.Price);
            
        }
        
        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        public void SetPrice_GivenInvalidParameters_ShouldThrowArgumentException(decimal invalidPrice)
        {
            var product = new Product(Name, Description, FlavorTest, Price);
            Assert.Throws<ArgumentException>(() => product.SetPrice(invalidPrice));
        }
    }
}