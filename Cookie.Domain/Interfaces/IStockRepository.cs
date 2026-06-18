using Cookie.Domain.Entities;
using Cookie.Domain.Pagination;

namespace Cookie.Domain.Interfaces;

public interface IStockRepository
{
    Task<Stock> AddAsync(Stock stock);
    Task<Stock?> UpdateAsync(Stock stock);
    Task<bool> DeleteAsync(int id);
    Task<PagedList<Stock>> GetAllAsync(int  pageNumber, int pageSize);
    Task<Stock?> GetByIdAsync(int id);
    
}