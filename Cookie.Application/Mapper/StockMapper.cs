using Cookie.Application.DTOs.StockDto;
using Cookie.Domain.Entities;

namespace Cookie.Application.Mapper;

public static class StockMapper
{
    public static Stock MapToStock(StockRequestDto stockRequestDto)
    {
        return new Stock
        {
            ProductId = stockRequestDto.ProductId,
            Quantity = stockRequestDto.Quantity,
            Price = stockRequestDto.Price,
        };
    }

    public static StockResponseDto MapToStockResponse(Stock stock)
    {
        return new StockResponseDto
        {
            StockId =  stock.Id,
            ProductId =  stock.ProductId,
            Quantity = stock.Quantity,
            Price = stock.Price,
            
        };
    }
    
    public static StockRequestDto MapToStockRequestDto(Stock stock)
    {
        return new StockRequestDto
        {
            ProductId = stock.ProductId,
            Quantity = stock.Quantity,
            Price = stock.Price,
        };
    }

    public static void UpdateStock(Stock stock, StockUpdateDto dto)
    {
        stock.ProductId = dto.ProductId ?? stock.ProductId;
        stock.Quantity = dto.Quantity ?? stock.Quantity;
        stock.Price = dto.Price ?? stock.Price;
    }
}