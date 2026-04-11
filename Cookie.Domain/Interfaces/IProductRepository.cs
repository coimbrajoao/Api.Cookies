using Cookie.Domain.Entities;

namespace Cookie.Domain.Interfaces;

public interface IProductRepository
{
    Task<Product> GetByIdAsync(int id);
    Task<List<Product>> GetAllAsync();
    Task<Product> AddAsync(Product product);
    Task<Product> UpdateAsync(Product product);
    Task<Product> DeleteAsync(int id);
}