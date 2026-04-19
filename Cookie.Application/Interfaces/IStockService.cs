using Cookie.Application.DTOs;
using Cookie.Application.DTOs.StockDto;
using Cookie.Domain.Entities;

namespace Cookie.Application.Interfaces;

public interface IStockService
{
    Task<List<StockResponseDto>> GetStocks();
    Task<StockResponseDto> GetStockById(int stockId);
    Task<StockResponseDto>  CreateStock(StockRequestDto stockRequestDto);
    Task<StockResponseDto> UpdateStock(int id, StockUpdateDto stockUpdateDto);
    Task<bool> DeleteStock(int stockId);
}