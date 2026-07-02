using Cookie.API.Extensions;
using Cookie.API.Models;
using Cookie.Application.DTOs.StockDto;
using Cookie.Application.Interfaces;
using Cookie.Domain.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cookie.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StockController(IStockService stockService) : Controller
{
    [HttpPost]
    [Authorize(Roles = "StockClerk,Admin")]
    
    public async Task<ActionResult> CreateStock(StockRequestDto stockRequestDto)
    {
        var CreatedStock = await stockService.CreateStock(stockRequestDto);
        if (CreatedStock == null)
        {
            return BadRequest("Não foi possivel criar o estoque");
        }
        
        return Ok(CreatedStock);
    }

    [HttpGet]
    [Authorize(Roles = "StockClerk,Admin")]
    public async Task<ActionResult> GetAllStock([FromQuery] PaginationParams paginationParams)
    {
        var allStock = await stockService.GetStocks(paginationParams.PageNumber, paginationParams.PageSize);
        
        Response.AddPaginationHeader(new PaginationHeader(paginationParams.PageNumber, paginationParams.PageSize, allStock.TotalPages, allStock.TotalCount));
        
        return Ok(allStock);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "StockClerk,Admin")]
    
    public async Task<ActionResult> GetStockById(int id)
    {
        var stockById = await stockService.GetStockById(id);
        
        return Ok(stockById);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> UpdateStock(int id, StockUpdateDto stockUpdatetDto)
    {
        var updateStock = await stockService.UpdateStock(id,stockUpdatetDto);
        
        return Ok(updateStock);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> DeleteStock(int id)
    {
        var stock = await stockService.DeleteStock(id);
       
        return Ok(new {Message = "Estoque excluido com sucesso"});
    }
    
}