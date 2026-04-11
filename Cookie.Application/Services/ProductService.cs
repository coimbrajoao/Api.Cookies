using Cookie.Application.DTOs;
using Cookie.Application.Interfaces;
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
        throw new NotImplementedException();
    }

    public async Task<List<ProductGetDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<ProductGetDto> AddAsync(ProductRequestDto product)
    {
        throw new NotImplementedException();
    }

    public async Task<ProductGetDto> UpdateAsync(ProductUpdateDTO product)
    {
        throw new NotImplementedException();
    }

    public async Task<ProductGetDto> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}