using System.ComponentModel.DataAnnotations;

namespace Cookie.Application.DTOs.StockDto;

public class StockRequestDto
{
    [Required]
    public int ProductId { get; set; }
    
    [Required]
    public int Quantity { get; set; }
    
}