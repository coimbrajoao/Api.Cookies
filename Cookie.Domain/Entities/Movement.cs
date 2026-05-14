using Cookie.Domain.Enum;

namespace Cookie.Domain.Entities;

public class Movement
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; private set; }
    public int Quantity { get; private set; }
    
    public int? IdMaster { get; private set; }
    public MovementType TypeMovement { get; private set; }
    public int StockId { get; private set; }
    
    public virtual Movement ParentMovement { get; set; }
    public virtual Stock  Stock { get; set; }
    
    public Movement(){}
    public Movement(MovementType type, int quantity,  int stockId, int? idMaster)
    {
        if (quantity <= 0)
            throw new ArgumentException("O valor deve ser maior que zero");
        TypeMovement = type;
        Quantity = quantity;
        CreatedAt = DateTime.UtcNow;
        StockId = stockId;
        IdMaster =  idMaster;
    }
    
    public Movement(MovementType type, int quantity,  int stockId)
    {
        if (quantity <= 0)
            throw new ArgumentException("O valor deve ser maior que zero");
        TypeMovement = type;
        Quantity = quantity;
        CreatedAt = DateTime.UtcNow;
        StockId = stockId;
    }

    
    public DateTime GetCreatedAt()
    {
        return CreatedAt;
    }

    public void SetIdMaster(int id)
    {
        IdMaster = id;
    }

    public Movement GenerateReversal()
    {
        var reversalType = this.TypeMovement == MovementType.Entry ? MovementType.Exit : MovementType.Exit;
        
        return new Movement(reversalType, Quantity, StockId, Id);
    }
    
}