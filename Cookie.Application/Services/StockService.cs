using Cookie.Application.DTOs.StockDto;
using Cookie.Application.Exceptions;
using Cookie.Application.Interfaces;
using Cookie.Application.Mapper;
using Cookie.Domain.Entities;
using Cookie.Domain.Interfaces;
using Cookie.Domain.Pagination;

namespace Cookie.Application.Services;

public class StockService(IStockRepository stockRepository, IProductRepository productRepository, IUnitOfWork uow) : IStockService

{
    public async Task<PagedList<StockResponseDto>> GetStocks(int pageNumber, int pageSize)
    {
        var list = await stockRepository.GetAllAsync(pageNumber, pageSize);
        
        var stockDto = list.Select(StockMapper.MapToStockResponse).ToList();
        return new PagedList<StockResponseDto>(stockDto, list.CurrentPage, list.PageSize, list.TotalCount);
    }

    public async Task<StockResponseDto> GetStockById(int stockId)
    {
        var stock = await stockRepository.GetByIdAsync(stockId);
        return (stock == null ? throw new NotFoundException("Estoque não foi encotrado"): StockMapper.MapToStockResponse(stock))!;
    }

    public async Task<StockResponseDto> CreateStock(StockRequestDto stockRequestDto)
    {
        var  stock = StockMapper.MapToStock(stockRequestDto);
        var product = await productRepository.GetByIdAsync(stock.ProductId);
        if (product == null)
        {
            throw new NotFoundException("Produto não encontrado");
        }
        stock.SetUnitPrice(product.Price);
        await stockRepository.AddAsync(stock);
        await uow.Save();

        return StockMapper.MapToStockResponse(stock);
    }

    public async Task<StockResponseDto> UpdateStock(int id, StockUpdateDto stockUpdateDto)
    {
        var stock = await stockRepository.GetByIdAsync(id);
        if (stock == null)
        {
            throw new NotFoundException("Estoque não foi encontrado");
        }

        if (stockUpdateDto.ProductId.HasValue && stockUpdateDto.ProductId != stock.ProductId)
        {
            var product = await productRepository.GetByIdAsync(stockUpdateDto.ProductId.Value);
            if (product == null)
            { 
                throw new NotFoundException("Produto não encontrado");
            }
        }
        
        await stockRepository.UpdateAsync(stock);
        await uow.Save();
        return StockMapper.MapToStockResponse(stock);
    }

    public async Task<bool> DeleteStock(int stockId)
    {
        var stock = await stockRepository.DeleteAsync(stockId);
        await uow.Save();
        return stock;
    }
}