namespace Cookie.Domain.Entities;

public class Stock
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; }
    public virtual Product? Product { get; set; }
}