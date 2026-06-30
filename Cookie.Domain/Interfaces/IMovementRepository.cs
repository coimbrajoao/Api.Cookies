using Cookie.Domain.Entities;
using Cookie.Domain.Pagination;

namespace Cookie.Domain.Interfaces;

public interface IMovementRepository
{
    Task<PagedList<Movement>> GetAllMovementsAsync(int pageNumber, int pageSize);
    Task<Movement> GetMovementByIdAsync(int Id);
    Task<Movement> AddMovementAsync(Movement movement);
}