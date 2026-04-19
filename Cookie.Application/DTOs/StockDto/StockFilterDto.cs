namespace Cookie.Application.DTOs.StockDto;

public class StockFilterDto
{
    public int? ProductId { get; set; }
    public int? MinQuantity { get; set; }
    public int? MaxQuantity { get; set; }
       
}