using Cookie.Application.DTOs;
using Cookie.Application.Exceptions;
using Cookie.Application.Interfaces;
using Cookie.Application.Mapper;
using Cookie.Domain.Entities;
using Cookie.Domain.Enum;
using Cookie.Domain.Interfaces;

namespace Cookie.Application.Services;

public class MovementService(IMovementRepository movementRepository, IStockRepository stockRepository) : IMovementService
{
    public async Task<IEnumerable<MovementResponseDto>> GetMovementsAsync()
    {
        var movements = await movementRepository.GetAllMovementsAsync();
        
        return movements.Select(MovementMapper.MapMovementResponse).ToList();
    }

    public async Task<MovementResponseDto> GetMovementAsync(int id)
    {
        var movement = await movementRepository.GetMovementByIdAsync(id);
        
        return movement == null ? throw new NotFoundException("Nenhum movimento foi encontrado") : MovementMapper.MapMovementResponse(movement);
    }

    public async Task<MovementResponseDto> AddMovementAsync(MovementRequestDto MovementResponseDto)
    {
        var movement = MovementMapper.MapMovement(MovementResponseDto);
        if (movement == null)
        {
            throw new NotFoundException("Nenhum movimento foi encontrado");
        }
        
        var stock = await stockRepository.GetByIdAsync(movement.StockId);

        if (stock == null)
        {
            throw new NotFoundException("Nenhum stock foi encontrado");
        }

        if (movement.TypeMovement == MovementType.Exit)
        {
            if (movement.Quantity < 0)
            {
                throw new NotFoundException("Valor de quantidade deve ser maior que 0.");
            }
            
            stock.DecreaseStock(movement.Quantity);
        }
        else
        {
            stock.IncreaseStock(movement.Quantity);
        }
        
        
        await movementRepository.AddMovementAsync(movement);
        await stockRepository.UpdateAsync(stock);
        return MovementMapper.MapMovementResponse(movement);
    }

    public Task<MovementResponseDto> UpdateMovementAsync(MovementResponseDto movementResponseDto )
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteMovementAsync(int id)
    {
        var deleted = await movementRepository.DeleteMovementAsync(id);

        if (deleted == null)
        {
            throw new NotFoundException("Nenhum movimento foi encontrado");
        }
        
        return deleted;
    }
}