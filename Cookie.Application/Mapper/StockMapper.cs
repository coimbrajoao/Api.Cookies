using Cookie.Application.DTOs.StockDto;
using Cookie.Domain.Entities;

namespace Cookie.Application.Mapper;

public static class StockMapper
{
    public static Stock MapToStock(StockRequestDto stockRequestDto, int userId)
    {
        return new Stock(stockRequestDto.ProductId, stockRequestDto.Quantity,userId);
    }

    public static StockResponseDto MapToStockResponse(Stock stock)
    {
        return new StockResponseDto
        {
            StockId =  stock.Id,
            ProductId =  stock.ProductId,
            Price = stock.UnitPrice,
            Quantity =  stock.Quantity,
            dueData = stock.DueDate.ToString("yyyy-MM-dd HH:mm:ss"),
            CreatedAt = stock.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss"),
            userId = stock.UserId
        };
    }
    
}