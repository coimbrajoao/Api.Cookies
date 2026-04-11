using Cookie.Application.DTOs;

namespace Cookie.Application.Interfaces;

public interface IProductService
{
    Task<ProductGetDto> GetByIdAsync(int id);
    Task<List<ProductGetDto>> GetAllAsync();
    Task<ProductGetDto> AddAsync(ProductRequestDto product);
    Task<ProductGetDto> UpdateAsync(ProductUpdateDTO product);
    Task<ProductGetDto> DeleteAsync(int id);
}