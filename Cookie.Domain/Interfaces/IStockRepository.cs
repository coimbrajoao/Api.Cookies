using Cookie.Domain.Entities;
using Cookie.Domain.Pagination;
using Cookie.Domain.Queries;

namespace Cookie.Domain.Interfaces;

public interface IStockRepository
{
    Task<Stock> AddAsync(Stock stock);
    Task<Stock?> UpdateAsync(Stock stock);
    Task<bool> DeleteAsync(int id);
    Task<PagedList<Stock>> GetAllAsync(int  pageNumber, int pageSize, StockFilter filterDto);
    Task<Stock?> GetByIdAsync(int id);
    Task<Stock?> GetStockByIdProductAsync(int id);
    
}