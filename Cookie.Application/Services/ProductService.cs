using Cookie.Application.DTOs.ProductDto;
using Cookie.Application.Interfaces;
using Cookie.Application.Mapper;
using Cookie.Domain.Interfaces;

namespace Cookie.Application.Services;

public class ProductService(IProductRepository productRepository) : IProductService
{
    public async Task<ProductGetDto> GetByIdAsync(int id)
    {
        var product =  await productRepository.GetByIdAsync(id);
        if (product == null)
        {
            return null;
        }
        var productGet = ProductMapper.MapToProductGetDto(product);

        return productGet;
    }

    public async Task<List<ProductGetDto>> GetAllAsync()
    {
        var list  = await productRepository.GetAllAsync();

        if (list == null)
        {
            return null;
        }
        return list.Select(ProductMapper.MapToProductGetDto).ToList();
    }

    public async Task<ProductGetDto> AddAsync(ProductRequestDto productGetDto)
    {
        var productPost = ProductMapper.MapToProduct(productGetDto);
        await productRepository.AddAsync(productPost);
        var productGet = ProductMapper.MapToProductGetDto(productPost);
        return productGet;
    }

    public async Task<ProductGetDto> UpdateAsync(int id,ProductUpdateDto productUpdateDto)
    {
        var productUpdate = await productRepository.GetByIdAsync(id);
        if (productUpdate == null)
        {
            throw new KeyNotFoundException("Produto não foi encontrado");
        }

        ProductMapper.MapToProductUpdateDto(productUpdate, productUpdateDto);
         await productRepository.UpdateAsync(productUpdate);
        
        return ProductMapper.MapToProductGetDto(productUpdate);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var product = await productRepository.DeleteAsync(id);
        return product;
    }
}