namespace Cookie.Application.DTOs.StockDto;

public class StockResponseDto
{
    public int StockId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    
}