using Cookie.Domain.Entities;
using Cookie.Domain.Interfaces;
using Cookie.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Cookie.Infra.Data.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;
    
    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<Product> GetByIdAsync(int id)
    {
        return await _context.Product.FindAsync(id);
    }

    public async Task<List<Product>> GetAllAsync()
    {
        return await _context.Product.ToListAsync();
    }

    public async Task<Product> AddAsync(Product product)
    {
        _context.Product.Add(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<Product> UpdateAsync(Product product)
    {
        _context.Product.Update(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<Product> DeleteAsync(int id)
    {
       var product = await _context.Product.FindAsync(id);
       if (product is null)
       {
           return null;
       }
       _context.Product.Remove(product);
       return product;
    }
}