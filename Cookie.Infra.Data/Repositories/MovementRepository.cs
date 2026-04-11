using Cookie.Domain.Entities;
using Cookie.Domain.Interfaces;
using Cookie.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using ZstdSharp.Unsafe;

namespace Cookie.Infra.Data.Repositories;

public class MovementRepository : IMovementRepository
{
    private readonly ApplicationDbContext _context;

    public MovementRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<List<Movement>> GetAllMovementsAsync()
    {
        return await _context.Movement.ToListAsync();
    }

    public async Task<Movement> GetMovementByIdAsync(int Id)
    {
        return await _context.Movement.FindAsync(Id);
    }

    public async Task<Movement> AddMovementAsync(Movement movement)
    {
        _context.Movement.Add(movement);
        await _context.SaveChangesAsync();
        return movement;
    }

    public async Task<Movement> UpdateMovementAsync(Movement movement)
    {
        _context.Movement.Update(movement);
        await _context.SaveChangesAsync();
        return movement;
    }
}