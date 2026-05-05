using System.ComponentModel.DataAnnotations;
using Cookie.Domain.Enum;

namespace Cookie.Application.DTOs;

public class MovementRequestDto
{
    [Required]
    public int Quantity { get; }
    
    [Required]
    public int StockId { get; }
    
    [Required]
    public MovementType TypeMovement { get; }
}