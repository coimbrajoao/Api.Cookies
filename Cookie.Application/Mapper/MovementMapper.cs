using Cookie.Application.DTOs.MovementDto;
using Cookie.Domain.Entities;

namespace Cookie.Application.Mapper;

public static class MovementMapper
{
    public static Movement MapMovement(MovementRequestDto movementRequestDto)
    {
        return new Movement(movementRequestDto.TypeMovement, movementRequestDto.Quantity, movementRequestDto.StockId);
    }

    public static MovementResponseDto MapMovementResponse(Movement movement)
    {
        return new MovementResponseDto()
        {
            Id = movement.Id,
            CreatedAt = movement.CreatedAt,
            StockId =  movement.StockId,
            TypeMovement = movement.TypeMovement,
            Quantity = movement.Quantity
        };
    }
}