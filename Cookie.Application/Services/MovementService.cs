using Cookie.Application.DTOs.MovementDto;
using Cookie.Application.Exceptions;
using Cookie.Application.Interfaces;
using Cookie.Application.Mapper;
using Cookie.Domain.Enum;
using Cookie.Domain.Interfaces;
using Cookie.Domain.Pagination;

namespace Cookie.Application.Services;

public class MovementService(IMovementRepository movementRepository, IStockRepository stockRepository) : IMovementService
{
    public async Task<PagedList<MovementResponseDto>> GetMovementsAsync(int pageNumber, int pageSize)
    {
        var movements = await movementRepository.GetAllMovementsAsync(pageNumber, pageSize);
        
        var movementsDto = movements
            .Select(MovementMapper.MapMovementResponse)
            .ToList();

        return new PagedList<MovementResponseDto>(movementsDto, movements.CurrentPage, movements.PageSize, movements.TotalCount);
        
    }

    public async Task<MovementResponseDto> GetMovementAsync(int id)
    {
        var movement = await movementRepository.GetMovementByIdAsync(id);
        
        return movement == null ? throw new NotFoundException("Nenhum movimento foi encontrado") : MovementMapper.MapMovementResponse(movement);
    }

    public async Task<MovementResponseDto> AddMovementAsync(MovementRequestDto movementResponseDto)
    {
        var movement = MovementMapper.MapMovement(movementResponseDto);
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

    public async Task<MovementResponseDto> RevertMovementAsync(int id)
    {
       var movement = await movementRepository.GetMovementByIdAsync(id);
       
       
       if (movement == null)
       {
           throw new NotFoundException("Nenhum movimento foi encontrado");
       }
       
       if (movement.IdMaster != null)
           throw new BadRequestException("Este movimento já é um estorno e não pode ser revertido.");
       
       var  stock = await stockRepository.GetByIdAsync(movement.StockId);

       if (stock == null)
       {
           throw new NotFoundException("Nenhum stock foi encontrado");
       }

       if (movement.TypeMovement == MovementType.Entry)
       {
           if (stock.Quantity < movement.Quantity)
           {
               throw new BadRequestException("Saldo insuficiente para estornar esta entrada.");
           }
           
           stock.DecreaseStock(movement.Quantity);
       }
       else
       {
           stock.IncreaseStock(movement.Quantity);
       }
       
       await movementRepository.AddMovementAsync(movement.CreateReversal());
       await stockRepository.UpdateAsync(stock);
       
       return MovementMapper.MapMovementResponse(movement);
    }

    public async Task<bool> DeleteMovementAsync(int id)
    {
        var deleted = await movementRepository.DeleteMovementAsync(id);

        return deleted;
    }
}