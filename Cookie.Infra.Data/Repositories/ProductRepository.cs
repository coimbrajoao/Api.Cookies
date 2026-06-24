using Cookie.Domain.Entities;
using Cookie.Domain.Interfaces;
using Cookie.Domain.Pagination;
using Cookie.Infra.Data.Context;
using Cookie.Infra.Data.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Cookie.Infra.Data.Repositories;

public class ProductRepository(ApplicationDbContext context) : IProductRepository
{
    public async Task<Product> GetByIdAsync(int id)
    {
        return await context.Product.FindAsync(id);
    }

    public async Task<PagedList<Product>> GetAllAsync(int pageNumber, int pageSize)
    {
        var query = context.Product.AsQueryable().AsNoTracking();

        return await PaginationHelper.CreateAsync(query, pageNumber, pageSize);
    }

    public async Task<Product> AddAsync(Product product)
    {
        context.Product.Add(product);
        return product;
    }

    public async Task<Product> UpdateAsync(Product product)
    {
        context.Product.Update(product);
        return product;
    }

    public async Task<bool> DeleteAsync(int id)
    {
       var product = await context.Product.FindAsync(id);
       if (product is null)
       {
           return false;
       }
       context.Product.Remove(product);
       return true;
    }
}