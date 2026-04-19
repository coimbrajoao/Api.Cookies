using Cookie.Application.DTOs.ProductDto;
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

    public static void MapToProductUpdateDto(Product product ,ProductUpdateDto productUpdateDto)
    {
        product.Description = productUpdateDto.Description ?? product.Description;
        product.Price = productUpdateDto.Price ?? product.Price;
        product.Flavor = productUpdateDto.Flavor  ?? product.Flavor;
        product.Name = productUpdateDto.Name ?? product.Name;
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