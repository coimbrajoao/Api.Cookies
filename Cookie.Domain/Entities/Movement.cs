using Cookie.Domain.Enum;

namespace Cookie.Domain.Entities;

public class Movement
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; private set; }
    
    public decimal Amount { get; private set; }
    public MovementType TypeMovement { get; private set; }
    
    public Movement(){}
    public Movement(MovementType type, decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("O valor deve ser maior que zero");
        TypeMovement = type;
        Amount = amount;
        CreatedAt = DateTime.UtcNow;
    }
    
}