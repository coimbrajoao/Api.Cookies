using Cookie.Domain.Entities;
using Cookie.Domain.Interfaces;
using Cookie.Domain.Pagination;
using Cookie.Infra.Data.Context;
using Cookie.Infra.Data.Helpers;
using Microsoft.EntityFrameworkCore;
using ZstdSharp.Unsafe;

namespace Cookie.Infra.Data.Repositories;

public class MovementRepository(ApplicationDbContext context) : IMovementRepository
{
    public async Task<PagedList<Movement>> GetAllMovementsAsync(int pageNumber, int pageSize)
    {
        var query = context.Movement.AsQueryable().AsNoTracking();
        
        return await PaginationHelper.CreateAsync(query, pageNumber, pageSize);
    }

    public async Task<Movement> GetMovementByIdAsync(int id)
    {
        return await context.Movement.FindAsync(id);
    }

    public async Task<Movement> AddMovementAsync(Movement movement)
    {
        context.Movement.Add(movement);
        return movement;
    }
    
    public async Task<bool> DeleteMovementAsync(int id)
    {
        var movement = await context.Movement.FindAsync(id);
        if (movement != null) context.Movement.Remove(movement);
        return true;
        
    }
}