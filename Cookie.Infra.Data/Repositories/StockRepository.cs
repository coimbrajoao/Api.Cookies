using Cookie.Domain.Entities;
using Cookie.Domain.Interfaces;

namespace Cookie.Infra.Data.Repositories;

public class StockRepository : IStockRepository
{
    public Task<Stock> AddAsync(Stock stock)
    {
        throw new NotImplementedException();
    }

    public Task<Stock?> UpdateAsync(Stock stock)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Stock>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Stock?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Stock>> GetByProductIdAsync(int productId)
    {
        throw new NotImplementedException();
    }
}