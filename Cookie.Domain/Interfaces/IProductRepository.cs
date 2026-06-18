using Cookie.Domain.Entities;
using Cookie.Domain.Pagination;

namespace Cookie.Domain.Interfaces;

public interface IProductRepository
{
    Task<Product> GetByIdAsync(int id);
    Task<PagedList<Product>> GetAllAsync(int pageNumber, int pageSize);
    Task<Product> AddAsync(Product product);
    Task<Product> UpdateAsync(Product product);
    Task<bool> DeleteAsync(int id);
}