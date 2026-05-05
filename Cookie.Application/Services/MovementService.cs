using Cookie.Application.DTOs;
using Cookie.Application.Interfaces;
using Cookie.Application.Mapper;
using Cookie.Domain.Entities;
using Cookie.Domain.Interfaces;

namespace Cookie.Application.Services;

public class MovementService(IMovementRepository movementRepository) : IMovementService
{
    public async Task<IEnumerable<MovementResponseDto>> GetMovementsAsync()
    {
        var movements = await movementRepository.GetAllMovementsAsync();
        
        return movements.Select(MovementMapper.MapMovementResponse).ToList();
    }

    public async Task<MovementResponseDto> GetMovementAsync(int id)
    {
        var movement = await movementRepository.GetMovementByIdAsync(id);
        
        return movement == null ? null : MovementMapper.MapMovementResponse(movement);
    }

    public async Task<MovementResponseDto> AddMovementAsync(MovementRequestDto MovementResponseDto)
    {
        var movement = MovementMapper.MapMovement(MovementResponseDto);
        await movementRepository.AddMovementAsync(movement);
        return MovementMapper.MapMovementResponse(movement);
    }

    public Task<MovementResponseDto> UpdateMovementAsync(MovementResponseDto movementResponseDto )
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteMovementAsync(int id)
    {
        var deleted = await movementRepository.DeleteMovementAsync(id);
        return deleted;
    }
}