namespace Cookie.Domain.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public string Flavor { get; private set; }
    public ICollection<Stock> Stocks { get; set; } = new List<Stock>();

    public Product(){}
    public Product(string name, string description, decimal price, string flavor)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("O Valor de nome não pode ser vazio ou nulo");
        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("O Valor de descrição não pode ser vazio ou nulo");
        if (string.IsNullOrWhiteSpace(flavor))
            throw new ArgumentException("O Valor de sabor não pode ser vazio ou nulo");
        if(price <= 0)
            throw new ArgumentException("O valor de precisa ser maior que zero");
        
        Name = name;
        Description = description;
        Price = price;
        Flavor = flavor;
    }
}