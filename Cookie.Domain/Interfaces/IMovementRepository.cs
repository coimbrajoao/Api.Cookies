using Cookie.Domain.Entities;

namespace Cookie.Domain.Interfaces;

public interface IMovementRepository
{
    Task<List<Movement>> GetAllMovementsAsync();
    Task<Movement> GetMovementByIdAsync(int movementId);
    Task<Movement> AddMovementAsync(Movement movement);
    Task<Movement> UpdateMovementAsync(Movement movement);
}