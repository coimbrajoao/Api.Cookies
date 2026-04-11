using Cookie.Domain.Entities;
using Cookie.Domain.Interfaces;

namespace Cookie.Infra.Data.Repositories;

public class MovementRepository : IMovementRepository
{
    public Task<List<Movement>> GetAllMovementsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Movement> GetMovementByIdAsync(int movementId)
    {
        throw new NotImplementedException();
    }

    public Task<Movement> AddMovementAsync(Movement movement)
    {
        throw new NotImplementedException();
    }

    public Task<Movement> UpdateMovementAsync(Movement movement)
    {
        throw new NotImplementedException();
    }
}