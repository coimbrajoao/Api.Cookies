using Cookie.Domain.Entities;
using Cookie.Domain.Interfaces;
using Cookie.Domain.Pagination;
using Cookie.Domain.Queries;
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

    public async Task<PagedList<Stock>> GetAllAsync(int  pageNumber, int pageSize, StockFilter filter )
    {
        var query = context.Stock.AsQueryable().AsNoTracking();

        if (!string.IsNullOrWhiteSpace(filter.Name))
            query = query.Where(s => s.Product.Name.Contains(filter.Name));
        

        if (!string.IsNullOrWhiteSpace(filter.OrderBy))
        {
            bool isAsc = filter.OrderByDirection == 0;

            query = filter.OrderBy.ToLower() switch
            {
                "name" => isAsc ? query.OrderBy(s => s.Product.Name) : query.OrderByDescending(s => s.Product.Name),
                "createdat" => isAsc ? query.OrderBy(s => s.CreatedAt) : query.OrderByDescending(s => s.CreatedAt),
                "price" => isAsc ? query.OrderBy(s => s.UnitPrice) : query.OrderByDescending(s => s.UnitPrice),
                _ => query.OrderBy(s => s.Id) 
            };
        }

        if (filter.MinQuantity.HasValue)
            query = query.Where(s => s.Quantity >= filter.MinQuantity.Value);

        if (filter.MaxQuantity.HasValue)
            query = query.Where(s => s.Quantity <= filter.MaxQuantity.Value);
        
        
        if(filter.MinDate.HasValue)
            query = query.Where(s => s.DueDate >= filter.MinDate.Value);
        
        if(filter.MaxDate.HasValue)
            query = query.Where(s => s.DueDate <= filter.MaxDate.Value);
        
        return await  PaginationHelper.CreateAsync(query, pageNumber, pageSize);
    }

    public async Task<Stock?> GetByIdAsync(int id)
    {
        return await context.Stock.FindAsync(id);
    }

    public async Task<Stock?> GetStockByIdProductAsync(int id)
    {
        return await context.Stock.FirstOrDefaultAsync(x => x.ProductId == id);
    }
}