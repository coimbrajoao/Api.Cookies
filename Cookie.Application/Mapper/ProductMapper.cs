using Cookie.Application.DTOs;
using Cookie.Domain.Entities;

namespace Cookie.Application.Mapper;

public static class ProductMapper
{
    public static Product MapToProduct(ProductRequestDto product)
    {
        return new Product
        {
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Flavor = product.Flavor,
        };
    }

    public static ProductGetDto MapToProductRequestDto(Product product)
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
    
    public static ProductUpdateDTO MapToProductUpdateDto(Product product, ProductUpdateDTO productDto)
    {
        
        return new ProductUpdateDTO
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Flavor = product.Flavor
        };
    }
    
}