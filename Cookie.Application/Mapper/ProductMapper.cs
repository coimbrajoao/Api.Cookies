using Cookie.Application.DTOs;
using Cookie.Domain.Entities;

namespace Cookie.Application.Mapper;

public static class ProductMapper
{
    public static Product MapToProduct(ProductRequestDto productRequest)
    {
        return new Product
        {
            Name = productRequest.Name,
            Description = productRequest.Description,
            Price = productRequest.Price,
            Flavor = productRequest.Flavor,
        };
    }

    public static Product mapToProductUpdateDto(ProductUpdateDTO productUpdateDto)
    {
        return new Product
        {
            Name = productUpdateDto.Name,
            Description = productUpdateDto.Description,
            Price = productUpdateDto.Price,
            Flavor = productUpdateDto.Flavor,
        };
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