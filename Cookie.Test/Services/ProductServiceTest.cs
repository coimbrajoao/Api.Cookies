using Bogus;
using Cookie.Application.DTOs.ProductDto;
using Cookie.Application.Exceptions;
using Cookie.Application.Interfaces;
using Cookie.Application.Services;
using Cookie.Domain.Entities;
using Cookie.Domain.Interfaces;
using Moq;

namespace Cookie.Test.Services;

public class ProductServiceTest
{
    private readonly Mock<IProductRepository> _productRepositoryMock;
    private readonly IProductService _productService;
    private readonly Faker _faker;

    private Product productTeste =
        new Product("Triplo", "triplo chocolate", "Nutela", 15);

    public ProductServiceTest()
    {
        _faker = new Faker();
        _productRepositoryMock = new Mock<IProductRepository>();
        _productService = new ProductService(_productRepositoryMock.Object);
    }

    public class Constructor : ProductServiceTest
    {
        [Fact]
        public async void CreateProduct_ShouldCreateProduct_WhenDataIsValid()
        {
            //arrange
            var product = new ProductRequestDto()
            {
                Name = _faker.Name.FirstName(),
                Description = _faker.Lorem.Paragraph(),
                Price = _faker.Random.Decimal(10, 100),
                Flavor = _faker.Lorem.Paragraph()
            };

            //act
            var result = await _productService.AddAsync(product);

            //assert
            Assert.NotNull(result);
            Assert.Equal(product.Name, result.Name);
            Assert.Equal(product.Description, result.Description);
            Assert.Equal(product.Price, result.Price);
            Assert.Equal(product.Flavor, result.Flavor);
            _productRepositoryMock.Verify(productRepository => productRepository.AddAsync(It.IsAny<Product>()),
                Times.Once);
        }


        [Fact]
        public async void CreateProduct_ShouldThrowValidationException_WhenNameIsInvalid()
        {
            var product = new ProductRequestDto()
            {
                Name = " ",
                Description = _faker.Lorem.Paragraph(),
                Price = _faker.Random.Decimal(10, 100),
                Flavor = _faker.Lorem.Paragraph()
            };

            var message = await Assert.ThrowsAsync<ArgumentException>(() => _productService.AddAsync(product));

            Assert.Equal("Nome invalido", message.Message);
        }

        [Fact]
        public async void CreateProduct_ShouldThrowValidationException_WhenDescriptionIsInvalid()
        {
            var product = new ProductRequestDto()
            {
                Name = _faker.Name.FirstName(),
                Description = null!,
                Price = _faker.Random.Decimal(10, 100),
                Flavor = _faker.Lorem.Paragraph()
            };

            var message = await Assert.ThrowsAsync<ArgumentException>(() => _productService.AddAsync(product));

            Assert.Equal("Descrição invalida", message.Message);
        }

        [Fact]
        public async void CreateProduct_ShouldThrowValidationException_WhenPriceIsInvalid()
        {
            var product = new ProductRequestDto()
            {
                Name = _faker.Name.FirstName(),
                Description = _faker.Lorem.Paragraph(),
                Price = -5,
                Flavor = _faker.Lorem.Paragraph()
            };

            var message = await Assert.ThrowsAsync<ArgumentException>(() => _productService.AddAsync(product));

            Assert.Equal("Preço deve ser maior que zero", message.Message);
        }

        [Fact]
        public async void CreateProduct_ShouldThrowValidationException_WhenFlavorIsInvalid()
        {
            var product = new ProductRequestDto()
            {
                Name = _faker.Name.FirstName(),
                Description = _faker.Lorem.Paragraph(),
                Price = _faker.Random.Decimal(10, 100),
                Flavor = null!
            };

            var message = await Assert.ThrowsAsync<ArgumentException>(() => _productService.AddAsync(product));

            Assert.Equal("Sabor invalido", message.Message);

        }
    }

    public class UpdateProduct : ProductServiceTest
    {
        [Fact]
        public async void UpdateProduct_ShouldUpdateProduct_WhenDataIsValid()
        {
            //arrange
            int id = 1;

            var productUpdate = new ProductUpdateDto
            {
                Name = _faker.Name.FirstName(),
                Description = _faker.Lorem.Paragraph(),
                Price = _faker.Random.Decimal(10, 100),
                Flavor = _faker.Lorem.Paragraph()
            };

            _productRepositoryMock.Setup(productRepository => productRepository.GetByIdAsync(id))
                .ReturnsAsync(productTeste);

            //Act
            var result = await _productService.UpdateAsync(id, productUpdate);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(productTeste.Name, result.Name);
            Assert.Equal(productTeste.Description, result.Description);
            Assert.Equal(productTeste.Price, result.Price);
            Assert.Equal(productTeste.Flavor, result.Flavor);
            _productRepositoryMock.Verify(r => r.UpdateAsync(It.IsAny<Product>()), Times.Once);
        }

        [Fact]
        public async void UpdateProduct_ShouldThrowValidationException_WhenDescriptionIsInvalid()
        {
            //arrange
            int id = 1;

            var productUpdate = new ProductUpdateDto
            {
                Name = _faker.Name.FirstName(),
                Description = "",
                Flavor = _faker.Lorem.Paragraph(),
                Price = _faker.Random.Decimal(10, 100)
            };
            _productRepositoryMock.Setup(productRepository => productRepository.GetByIdAsync(id))
                .ReturnsAsync(productTeste);

            //Act
            var message =
                await Assert.ThrowsAsync<ArgumentException>(() => _productService.UpdateAsync(id, productUpdate));

            //Assert
            Assert.NotNull(message);
            Assert.Equal("Descrição invalida", message.Message);
        }


        [Fact]
        public async void UpdateProduct_ShouldThrowValidationException_WhenNameIsInvalid()
        {
            //arrange
            int id = 1;

            var productUpdate = new ProductUpdateDto
            {
                Name = " ",
                Description = _faker.Lorem.Paragraph(),
                Flavor = _faker.Lorem.Paragraph(),
                Price = _faker.Random.Decimal(10, 100)
            };
            _productRepositoryMock.Setup(productRepository => productRepository.GetByIdAsync(id))
                .ReturnsAsync(productTeste);

            //Act
            var message =
                await Assert.ThrowsAsync<ArgumentException>(() => _productService.UpdateAsync(id, productUpdate));

            //Assert
            Assert.NotNull(message);
            Assert.Equal("Nome invalido", message.Message);
        }


        [Fact]
        public async void UpdateProduct_ShouldThrowValidationException_WhenFlavorIsInvalid()
        {
            //arrange
            int id = 1;

            var productUpdate = new ProductUpdateDto
            {
                Name = _faker.Name.FirstName(),
                Description = _faker.Lorem.Paragraph(),
                Flavor = " ",
                Price = _faker.Random.Decimal(10, 100)
            };
            _productRepositoryMock.Setup(productRepository => productRepository.GetByIdAsync(id))
                .ReturnsAsync(productTeste);

            //Act
            var message = await Assert.ThrowsAsync<ArgumentException>(() => _productService.UpdateAsync(id, productUpdate));

            //Assert
            Assert.NotNull(message);
            Assert.Equal("Sabor invalido", message.Message);
        }
        
        
        [Fact]
        public async void UpdateProduct_ShouldThrowValidationException_WhenPriceIsInvalid()
        {
            //arrange
            int id = 1;
            
            var productUpdate = new ProductUpdateDto
            {
                Name = _faker.Name.FirstName(),
                Description = _faker.Lorem.Paragraph(),
                Flavor = _faker.Lorem.Paragraph(),
                Price = -5
            };
            _productRepositoryMock.Setup(productRepository => productRepository.GetByIdAsync(id))
                .ReturnsAsync(productTeste);
            
            //Act
            var message = await Assert.ThrowsAsync<ArgumentException>(() => _productService.UpdateAsync(id, productUpdate));
            
            //Assert
            Assert.NotNull(message);
            Assert.Equal("Preço deve ser maior que zero", message.Message);
        }
    }

    public class GetProduct : ProductServiceTest
    {
        [Fact]
        public async void should_ReturnProduct_When_IdExists()
        {
            //arrange
            int id = 1;

            _productRepositoryMock.Setup(productRepository => productRepository.GetByIdAsync(id))
                .ReturnsAsync(productTeste);
            
            //act
            var result = await _productService.GetByIdAsync(id);
            
            //assert
            Assert.NotNull(result);
            Assert.Equal(productTeste.Name, result.Name);
            Assert.Equal(productTeste.Description, result.Description);
            Assert.Equal(productTeste.Price, result.Price);
            Assert.Equal(productTeste.Flavor, result.Flavor);
        }

        [Fact]
        public async void should_ReturnNull_When_IdNotExists()
        {
            //arrange
            int id = 1;

            _productRepositoryMock.Setup(productRepository => productRepository.GetByIdAsync(id))!
                .ReturnsAsync((Product)null!);
            
            //act
            var message = await Assert.ThrowsAsync<NotFoundException>(()=> _productService.GetByIdAsync(id));
            
            //Assert
            Assert.NotNull(message);
            Assert.Equal("Produto não foi encontrado", message.Message);
        }
    }
    
}