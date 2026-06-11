using Cookie.Domain.Entities;
using Cookie.Domain.Interfaces;
using Cookie.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using ZstdSharp.Unsafe;

namespace Cookie.Infra.Data.Repositories;

public class MovementRepository(ApplicationDbContext context) : IMovementRepository
{
    public async Task<List<Movement>> GetAllMovementsAsync()
    {
        return await context.Movement.ToListAsync();
    }

    public async Task<Movement> GetMovementByIdAsync(int id)
    {
        return await context.Movement.FindAsync(id);
    }

    public async Task<Movement> AddMovementAsync(Movement movement)
    {
        context.Movement.Add(movement);
        await context.SaveChangesAsync();
        return movement;
    }
    
    public async Task<bool> DeleteMovementAsync(int id)
    {
        var movement = await context.Movement.FindAsync(id);
        if (movement != null) context.Movement.Remove(movement);
        await  context.SaveChangesAsync();
        return true;
        
    }
}