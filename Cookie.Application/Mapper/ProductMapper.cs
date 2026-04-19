using Cookie.Application.DTOs.ProductDto;
using Cookie.Domain.Entities;

namespace Cookie.Application.Mapper;

public static class ProductMapper
{
    public static Product MapToProduct(ProductRequestDto productRequest)
    {
        return new Product(productRequest.Name, productRequest.Description,productRequest.Flavor,productRequest.Price);
  
    }
    
    
    public static ProductGetDto MapToProductGetDto(Product product)
    {
        return new ProductGetDto()
        {
            Id =  product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Flavor = product.Flavor
        };
    }

}