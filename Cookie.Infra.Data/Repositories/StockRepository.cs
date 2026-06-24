using System.Runtime.CompilerServices;
using Cookie.Domain.Entities;
using Cookie.Domain.Interfaces;
using Cookie.Domain.Pagination;
using Cookie.Infra.Data.Context;
using Cookie.Infra.Data.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Cookie.Infra.Data.Repositories;

public class StockRepository(ApplicationDbContext context) : IStockRepository
{
    public async Task<Stock> AddAsync(Stock stock)
    {
        context.Stock.Add(stock);
        return stock;
    }

    public async Task<Stock?> UpdateAsync(Stock stock)
    {
        context.Stock.Update(stock);
        return stock;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var  stock = await context.Stock.FindAsync(id);
        if (stock == null) return false;
        context.Stock.Remove(stock);
        return true;

    }

    public async Task<PagedList<Stock>> GetAllAsync(int  pageNumber, int pageSize)
    {
        var query = context.Stock.AsQueryable().AsNoTracking();
        return await  PaginationHelper.CreateAsync(query, pageNumber, pageSize);
    }

    public async Task<Stock?> GetByIdAsync(int id)
    {
        return await context.Stock.FindAsync(id);
    }
    
}