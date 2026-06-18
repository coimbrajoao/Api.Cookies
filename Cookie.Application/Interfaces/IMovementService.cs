using Cookie.Application.DTOs.MovementDto;
using Cookie.Domain.Pagination;

namespace Cookie.Application.Interfaces;

public interface IMovementService
{
    
    Task<PagedList<MovementResponseDto>> GetMovementsAsync(int pageNumber, int pageSize);
    Task<MovementResponseDto> GetMovementAsync(int id);
    Task<MovementResponseDto> AddMovementAsync(MovementRequestDto movement);
    Task<MovementResponseDto> RevertMovementAsync(int id);
    Task<bool> DeleteMovementAsync(int id);
    
}