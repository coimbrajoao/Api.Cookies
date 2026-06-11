using Cookie.Domain.Entities;
using Cookie.Domain.Interfaces;
using Cookie.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Cookie.Infra.Data.Repositories;

public class ProductRepository(ApplicationDbContext context) : IProductRepository
{
    public async Task<Product> GetByIdAsync(int id)
    {
        return await context.Product.FindAsync(id);
    }

    public async Task<List<Product>> GetAllAsync()
    {
        return await context.Product.ToListAsync();
    }

    public async Task<Product> AddAsync(Product product)
    {
        context.Product.Add(product);
        await context.SaveChangesAsync();
        return product;
    }

    public async Task<Product> UpdateAsync(Product product)
    {
        context.Product.Update(product);
        await context.SaveChangesAsync();
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
       await context.SaveChangesAsync();
       return true;
    }
}