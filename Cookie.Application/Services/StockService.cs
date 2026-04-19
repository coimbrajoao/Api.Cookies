using Cookie.Application.DTOs.StockDto;
using Cookie.Application.Interfaces;
using Cookie.Application.Mapper;
using Cookie.Domain.Entities;
using Cookie.Domain.Interfaces;

namespace Cookie.Application.Services;

public class StockService(IStockRepository stockRepository, IProductRepository productRepository) : IStockService

{
    public async Task<List<StockResponseDto>> GetStocks()
    {
        var list = await stockRepository.GetAllAsync();
        return list.Select(StockMapper.MapToStockResponse).ToList();
    }

    public async Task<StockResponseDto> GetStockById(int stockId)
    {
        var stock = await stockRepository.GetByIdAsync(stockId);
        return (stock == null ? throw new KeyNotFoundException("Estoque não foi encotrado"): StockMapper.MapToStockResponse(stock))!;
    }

    public async Task<StockResponseDto> CreateStock(StockRequestDto stockRequestDto)
    {
        var  stock = StockMapper.MapToStock(stockRequestDto);
        var product = await productRepository.GetByIdAsync(stock.ProductId);
        if (product == null)
        {
            throw new KeyNotFoundException("Produto não encontrado");
        }
        stock.SetUnitPrice(product.Price);
        await stockRepository.AddAsync(stock);
        return StockMapper.MapToStockResponse(stock);
    }

    public async Task<StockResponseDto> UpdateStock(int id, StockUpdateDto stockUpdateDto)
    {
        var stock = await stockRepository.GetByIdAsync(id);
        if (stock == null)
        {
            throw new KeyNotFoundException("Estoque não foi encontrado");
        }

        if (stockUpdateDto.ProductId.HasValue && stockUpdateDto.ProductId != stock.ProductId)
        {
            var product = await productRepository.GetByIdAsync(stockUpdateDto.ProductId.Value);
            if (product == null)
            { 
                throw new KeyNotFoundException("Produto não encontrado");
            }
        }
        
        
        await stockRepository.UpdateAsync(stock);
        return StockMapper.MapToStockResponse(stock);
    }

    public async Task<bool> DeleteStock(int stockId)
    {
        var stock = await stockRepository.DeleteAsync(stockId);
        return stock;
    }
}