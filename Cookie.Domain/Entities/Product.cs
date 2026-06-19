namespace Cookie.Domain.Entities;

public class Product
{
    public int Id { get; }
    public string Name { get;  private set; } = null!;
    public string Description { get;  private set; } = null!;
    public decimal Price { get;  private set; }
    public string Flavor { get;  private set; } = null!;
    public ICollection<Stock> Stocks { get; init; } = new List<Stock>();

    public Product(){}
    public Product(string name, string description, string flavor, decimal price)
    {
        UpdateName(name);
        UpdateDescription(description);
        UpdateFlavor(flavor);
        SetPrice(price);
    }

    public void SetPrice(decimal price)
    {
        if (price <= 0)
            throw new ArgumentException("Preço deve ser maior que zero");

        if (price == Price)
        {
            return;
        }
        
        
        Price = price;
    }

    public void UpdateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Nome invalido");
        }
        
        if(name == Name)
            return;
        
        Name = name;
    }

    public void UpdateDescription(string description)
    {
        if (string.IsNullOrWhiteSpace(description))
        {
           throw new ArgumentException("Descrição invalida");
        }
        
        if(description == Description)
            return;
        
        Description = description;
    }

    public void UpdateFlavor(string flavor)
    {
        if (string.IsNullOrWhiteSpace(flavor))
        {
            throw new ArgumentException("Sabor invalido");
        }
        
        if (flavor == Flavor) 
            return;
        Flavor = flavor;
    }
    

}