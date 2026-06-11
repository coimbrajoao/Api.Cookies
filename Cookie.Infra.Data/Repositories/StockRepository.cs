using System.Runtime.CompilerServices;
using Cookie.Domain.Entities;
using Cookie.Domain.Interfaces;
using Cookie.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Cookie.Infra.Data.Repositories;

public class StockRepository(ApplicationDbContext context) : IStockRepository
{
    public async Task<Stock> AddAsync(Stock stock)
    {
        context.Stock.Add(stock);
        await context.SaveChangesAsync();
        return stock;
    }

    public async Task<Stock?> UpdateAsync(Stock stock)
    {
        context.Stock.Update(stock);
        await context.SaveChangesAsync();
        return stock;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var  stock = await context.Stock.FindAsync(id);
        if (stock == null) return false;
        context.Stock.Remove(stock);
        await context.SaveChangesAsync();
        return true;

    }

    public async Task<List<Stock>> GetAllAsync()
    {
        return await context.Stock.ToListAsync();
    }

    public async Task<Stock?> GetByIdAsync(int id)
    {
        return await context.Stock.FindAsync(id);
    }

    public async Task<List<Stock>> GetByProductIdAsync(int productId)
    {
        context.Stock.Find(productId);
        return await context.Stock.ToListAsync();
    }
}