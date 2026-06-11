using Cookie.Application.DTOs.MovementDto;

namespace Cookie.Application.Interfaces;

public interface IMovementService
{
    
    Task<IEnumerable<MovementResponseDto>> GetMovementsAsync();
    Task<MovementResponseDto> GetMovementAsync(int id);
    Task<MovementResponseDto> AddMovementAsync(MovementRequestDto movement);
    Task<MovementResponseDto> RevertMovementAsync(int id);
    Task<bool> DeleteMovementAsync(int id);
    
}