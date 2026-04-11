namespace Cookie.Domain.Entities;

public class Stock
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public virtual Product? Product { get; set; }
    
    public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();
    public Stock(){}

    public Stock(int productId, int quantity, decimal price)
    {
        if(productId == 0)
            throw new ArgumentException("Um produto deve ser informado");
        if(quantity == 0)
            throw new ArgumentException("O valor de quantidade deve ser maior que zero");
        if(price <= 0)
            throw new ArgumentException("O valor do preço deve ser maior que zero");
        
        ProductId = productId;
        Quantity = quantity;
        Price = price;
    }
}