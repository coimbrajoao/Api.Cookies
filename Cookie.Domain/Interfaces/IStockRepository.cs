using Cookie.Domain.Entities;

namespace Cookie.Domain.Interfaces;

public interface IStockRepository
{
    Task<Stock> AddAsync(Stock stock);
    Task<Stock?> UpdateAsync(Stock stock);
    Task<bool> DeleteAsync(int id);
    Task<List<Stock>> GetAllAsync();
    Task<Stock?> GetByIdAsync(int id);
    Task<List<Stock>> GetByProductIdAsync(int productId);
    
}