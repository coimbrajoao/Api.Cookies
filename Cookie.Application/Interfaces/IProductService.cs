using Cookie.Application.DTOs.ProductDto;

namespace Cookie.Application.Interfaces;

public interface IProductService
{
    Task<ProductGetDto> GetByIdAsync(int id);
    Task<List<ProductGetDto>> GetAllAsync();
    Task<ProductGetDto> AddAsync(ProductRequestDto product);
    Task<ProductGetDto> UpdateAsync(int id, ProductUpdateDto product);
    Task<bool> DeleteAsync(int id);
}