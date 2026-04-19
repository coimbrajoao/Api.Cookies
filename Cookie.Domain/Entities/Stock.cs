namespace Cookie.Domain.Entities;

public class Stock
{
    public int Id { get; set; }
    public int ProductId { get; private set; }
    public int Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public virtual Product? Product { get; set; }
    
    public Stock(){}

    public Stock(int productId, int quantity)
    {
        if(productId == 0)
            throw new ArgumentException("Um produto deve ser informado");
        
        ProductId = productId;
        SetQuantity(quantity);
    }
    
    public void SetUnitPrice(decimal unitPrice)
    {
        if(unitPrice < 0)
            throw new ArgumentException("O valor unitario deve ser maior que zero");
        UnitPrice = unitPrice;
    }

    private void SetQuantity(int quantity)
    {
        Quantity = quantity;
    }

    public void IncreaseStock(int quantity)
    {
        if (quantity < 0)
        {
            throw new ArgumentException("A quantidade deve ser maior que zero");
        }
        
        Quantity += quantity;
    }

    public void DecreaseStock(int quantity)
    {
        if (Quantity == 0)
        {
            throw new ArgumentException("A quantidade do produto é igual a zero");
        }

        if (Quantity < quantity)
        {
            throw new ArgumentException("O valor e maior que a quantidade disponivel");
        }

        if (quantity is 0 or < 0)
        {
            throw new ArgumentException("A quantidade deve ser maior que zero");
        }

        Quantity -= quantity;
    }
}