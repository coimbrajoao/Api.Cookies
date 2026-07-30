using Cookie.Domain.Enum;
using Cookie.Domain.Exceptions;

namespace Cookie.Domain.Entities;

public class Movement
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; private set; }
    public int Quantity { get; private set; }
    
    public int? IdMaster { get; private set; }
    public MovementType TypeMovement { get; private set; }
    public int StockId { get; private set; }
    
    public int UserId {get; private set; }
    public Movement ParentMovement { get; set; }
    public User User { get; set; }
    public Stock  Stock { get; set; }
    
    public Movement(){}
    
    public Movement(MovementType type, int quantity,  int stockId, int userId, int? idMaster =  null)
    {
        if (quantity <= 0)
            throw new DomainExceptions("O valor deve ser maior que zero");
        
        if (stockId <= 0)
            throw new DomainExceptions("Um estoque deve ser informado");
        
        TypeMovement = type;
        Quantity = quantity;
        CreatedAt = DateTime.UtcNow;
        StockId = stockId;
        IdMaster =  idMaster;
        UserId = userId;
    }
    
    
    public Movement CreateReversal()
    {
        if (this.IdMaster.HasValue)
        {
            throw new DomainExceptions("O movimento é uma reversão e não pode ser revertido novamente");
        }
        var reversalType = this.TypeMovement == MovementType.Entry ? MovementType.Exit : MovementType.Entry;
        
        return new Movement(reversalType, Quantity, StockId, Id);
    }
    
}