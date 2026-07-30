using Bogus;
using Cookie.Domain.Entities;
using Cookie.Domain.Enum;
using Cookie.Domain.Exceptions;

namespace Cookie.Test.Entities;

public class MovementTest
{
    private const int StockId = 1;
    private const int ValidQuantity = 10;
    private const int MovementId = 1;
    
    
    public class Contructor : MovementTest
    {
        [Fact]
        public void constructor_GivenAllParams_ShouldSetProperties()
        {
            var movement = new Movement(MovementType.Entry, ValidQuantity,1, StockId);
            
            Assert.Equal(MovementType.Entry, movement.TypeMovement);
            Assert.Equal(StockId, movement.StockId);
            Assert.Equal(ValidQuantity, movement.Quantity);
        }

        [Fact]
        public void constructor_GivenAllParams_ShouldThrowException()
        {
            Assert.Throws<DomainExceptions>(() => new Movement(MovementType.Entry, -5, 1, StockId));
        }
    }

    public class ReversalMovement : MovementTest
    {
        [Fact]
        public void CreateReversal_GivenReversalMovement()
        {
            var movement = new Movement(MovementType.Entry, ValidQuantity,  StockId, 1);

            var movementReversal = movement.CreateReversal();
            
            Assert.NotEqual(movement.TypeMovement, movementReversal.TypeMovement);
            Assert.Equal(movement.Quantity, movementReversal.Quantity);
            Assert.Equal(movement.StockId, movementReversal.StockId);
            Assert.Equal(movement.Id, movementReversal.IdMaster);
        }

        [Fact]
        public void CreateReversal_GivenReversalMovement_ShouldThrowException()
        {
            var movement = new Movement(MovementType.Entry, 10, StockId ,1);
            
            var movementReversal = movement.CreateReversal();
            
            Assert.Throws<DomainExceptions>(() => movementReversal.CreateReversal());
            
        }
    }
    
}