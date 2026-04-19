namespace Cookie.Application.DTOs.StockDto;

public class StockUpdateDto
{
    public int? ProductId { get; set; }
    public int? Quantity { get; set; }
    public decimal? Price { get; set; }
}