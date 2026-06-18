using Cookie.Application.DTOs.StockDto;
using Cookie.Domain.Pagination;

namespace Cookie.Application.Interfaces;

public interface IStockService
{
    Task<PagedList<StockResponseDto>> GetStocks(int pageNumber, int pageSize);
    Task<StockResponseDto> GetStockById(int stockId);
    Task<StockResponseDto>  CreateStock(StockRequestDto stockRequestDto);
    Task<StockResponseDto> UpdateStock(int id, StockUpdateDto stockUpdateDto);
    Task<bool> DeleteStock(int stockId);
}