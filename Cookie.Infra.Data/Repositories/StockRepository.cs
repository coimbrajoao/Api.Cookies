using System.Runtime.CompilerServices;
using Cookie.Domain.Entities;
using Cookie.Domain.Interfaces;
using Cookie.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Cookie.Infra.Data.Repositories;

public class StockRepository : IStockRepository
{
    private ApplicationDbContext _context;

    public StockRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<Stock> AddAsync(Stock stock)
    {
        _context.Stock.Add(stock);
        await _context.SaveChangesAsync();
        return stock;
    }

    public async Task<Stock?> UpdateAsync(Stock stock)
    {
        _context.Stock.Update(stock);
        await _context.SaveChangesAsync();
        return stock;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var  stock = _context.Stock.Find(id);
        if (stock != null)
        {
            _context.Stock.Remove(stock);
            return true;
        }

        return false;
    }

    public async Task<List<Stock>> GetAllAsync()
    {
        return await _context.Stock.ToListAsync();
    }

    public async Task<Stock?> GetByIdAsync(int id)
    {
        return await _context.Stock.FindAsync(id);
    }

    public async Task<List<Stock>> GetByProductIdAsync(int productId)
    {
        _context.Stock.Find(productId);
        return await _context.Stock.ToListAsync();
    }
}