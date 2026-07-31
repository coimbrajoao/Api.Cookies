using Cookie.Domain.Enum;

namespace Cookie.Domain.Queries;

public class StockFilter
{
    public int? MinQuantity { get; set; }
    public int? MaxQuantity { get; set; }
    public DateTime? MinDate { get; set; }
    public DateTime? MaxDate { get; set; }
    public string? OrderBy { get; set; }
    
    public OrderByDirection? OrderByDirection { get; set; }
    public string? Name {get; set;}
}