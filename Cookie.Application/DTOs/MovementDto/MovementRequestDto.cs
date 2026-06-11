using System.ComponentModel.DataAnnotations;
using Cookie.Domain.Enum;

namespace Cookie.Application.DTOs.MovementDto;

public class MovementRequestDto
{
    [Required]
    public int Quantity { get; set; }
    
    [Required]
    public int StockId { get;set; }
    
    [Required]
    public MovementType TypeMovement { get; set;}
}