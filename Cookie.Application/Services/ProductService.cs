using Cookie.Application.DTOs;
using Cookie.Application.Interfaces;
using Cookie.Application.Mapper;
using Cookie.Domain.Interfaces;

namespace Cookie.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    
    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    
    public async Task<ProductGetDto> GetByIdAsync(int id)
    {
        var product =  await _productRepository.GetByIdAsync(id);
        if (product == null)
        {
            return null;
        }
        var productGet = ProductMapper.MapToProductGetDto(product);

        return productGet;
    }

    public async Task<List<ProductGetDto>> GetAllAsync()
    {
        var list  = await _productRepository.GetAllAsync();

        if (list == null)
        {
            return null;
        }
        return list.Select(ProductMapper.MapToProductGetDto).ToList();
    }

    public async Task<ProductGetDto> AddAsync(ProductRequestDto productGetDto)
    {
        var productPost = ProductMapper.MapToProduct(productGetDto);
        await _productRepository.AddAsync(productPost);
        var productGet = ProductMapper.MapToProductGetDto(productPost);
        return productGet;
    }

    public async Task<ProductGetDto> UpdateAsync(ProductUpdateDTO productUpdateDto)
    {
        var product  = ProductMapper.mapToProductUpdateDto(productUpdateDto);
        
        var updateProduct =  await _productRepository.UpdateAsync(product);
        if (updateProduct == null)
        {
            return null;
        }

        return ProductMapper.MapToProductGetDto(updateProduct);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var product = await _productRepository.DeleteAsync(id);
        return product;
    }
}