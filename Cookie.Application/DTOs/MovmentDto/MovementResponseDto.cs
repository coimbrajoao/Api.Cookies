using Cookie.Domain.Enum;

namespace Cookie.Application.DTOs;

public class MovementResponseDto
{
    public int Id { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public int Quantity { get; set; }
    
    public MovementType TypeMovement { get; set; }
    
    public int StockId { get; set; }
}