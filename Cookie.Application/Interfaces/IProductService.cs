using Cookie.Application.DTOs.ProductDto;
using Cookie.Domain.Pagination;

namespace Cookie.Application.Interfaces;

public interface IProductService
{
    Task<ProductGetDto> GetByIdAsync(int id);
    Task<PagedList<ProductGetDto>> GetAllAsync(int  pageNumber, int pageSize);
    Task<ProductGetDto> AddAsync(ProductRequestDto product);
    Task<ProductGetDto> UpdateAsync(int id, ProductUpdateDto product);
    Task<bool> DeleteAsync(int id);
}