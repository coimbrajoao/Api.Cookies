using Cookie.Application.DTOs.StockDto;
using Cookie.Domain.Entities;

namespace Cookie.Application.Mapper;

public static class StockMapper
{
    public static Stock MapToStock(StockRequestDto stockRequestDto)
    {
        return new Stock(stockRequestDto.ProductId, stockRequestDto.Quantity);
    }

    public static StockResponseDto MapToStockResponse(Stock stock)
    {
        return new StockResponseDto
        {
            StockId =  stock.Id,
            ProductId =  stock.ProductId,
            Price = stock.UnitPrice,
            Quantity =  stock.Quantity,
        };
    }
    
}