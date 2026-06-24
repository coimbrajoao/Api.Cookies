using Bogus;
using Cookie.Application.DTOs.MovementDto;
using Cookie.Application.Exceptions;
using Cookie.Application.Interfaces;
using Cookie.Application.Mapper;
using Cookie.Application.Services;
using Cookie.Domain.Entities;
using Cookie.Domain.Enum;
using Cookie.Domain.Interfaces;
using Moq;

namespace Cookie.Test.Services;

public class MovementServiceTest
{
    private readonly Mock<IStockRepository> _stockRepositoryMock;
    private readonly Mock<IMovementRepository> _movementRepositoryMock;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    
    private readonly IMovementService _movementService;
    private readonly Faker _faker;

    private Stock stockTest = new Stock(1 , 10);

    private Movement movementTest = new Movement(0, 10, 1);
    
    public MovementServiceTest()
    {
        _faker = new Faker();
        _stockRepositoryMock = new Mock<IStockRepository>();
        _movementRepositoryMock = new Mock<IMovementRepository>();
        _movementService = new MovementService( _movementRepositoryMock.Object,_stockRepositoryMock.Object, _unitOfWorkMock.Object);
        
    }
    
    public class AddMovement :  MovementServiceTest
    {
        [Fact]
        public async void CreateMovement_WithValidEntryData_ShouldAddMovement()
        {
            //arrange
            var movementDto = new MovementRequestDto
            {
                Quantity = 10,
                StockId = 1,
                TypeMovement = MovementType.Exit
            };
            
            var movement = MovementMapper.MapMovement(movementDto);
            
            _movementRepositoryMock.Setup(repo => repo.AddMovementAsync(movement)).ReturnsAsync(movement);
            _stockRepositoryMock.Setup(repoStock => repoStock.GetByIdAsync(1)).ReturnsAsync(stockTest);
            
            //act
            var result = await _movementService.AddMovementAsync(movementDto);
            
            //assert
            Assert.NotNull(result);
            Assert.Equal(movementDto.Quantity, result.Quantity);
            Assert.Equal(movementDto.StockId, result.StockId);
            Assert.Equal(MovementType.Exit, result.TypeMovement);
        }

        [Fact]
        public async void CreateMovement_WithInvalidQuantity_ShouldThrowException()
        {
            var movementDto = new MovementRequestDto
            {
                Quantity = -5,
                StockId = 1,
                TypeMovement = MovementType.Exit
            };
            
            var message = await Assert.ThrowsAsync<ArgumentException>(() => _movementService.AddMovementAsync(movementDto));
            
            Assert.NotNull(message);
            Assert.Equal("O valor deve ser maior que zero", message.Message);            
        }

        [Fact]
        public async void CreateMovement_WithInvalidStockId_ShouldThrowException()
        {
            var movementDto = new MovementRequestDto
            {
                Quantity = 5,
                StockId = 1,
                TypeMovement = MovementType.Entry
            };

            _stockRepositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((Stock)null!);
            
            var message = await Assert.ThrowsAsync<NotFoundException>(() => _movementService.AddMovementAsync(movementDto));

            Assert.NotNull(message);
            Assert.Equal("Nenhum stock foi encontrado", message.Message);
        }

        [Fact]
        public async void CreateMovement_WithNegativeStockId_ShouldThrowException()
        {
            var movementDto = new MovementRequestDto
            {
                Quantity = 5,
                StockId = -1,
                TypeMovement = MovementType.Entry
            };

            
            var message = await Assert.ThrowsAsync<ArgumentException>(() => _movementService.AddMovementAsync(movementDto));

            Assert.NotNull(message);
            Assert.Equal("Um estoque deve ser informado", message.Message);
        }
        
        
    }
}