using Cookie.Domain.Enum;

namespace Cookie.Domain.Entities;

public class Movement
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public decimal Amount { get; set; }
    public MovementType TypeMovement { get; set; }
}