using Cookie.API.Extensions;
using Cookie.API.Models;
using Cookie.Application.DTOs.MovementDto;
using Cookie.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cookie.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MovementController(IMovementService movementService) : Controller
{

    [HttpPost]
    [Authorize(Roles = "StockClerk,Admin")]
    
    public async Task<ActionResult> AddMovementAsync(MovementRequestDto movementRequestDto)
    {
        var movement = await movementService.AddMovementAsync(movementRequestDto);
        return Ok(movement);
    }

    [HttpGet]
    [Authorize(Roles = "StockClerk,Admin")]
    
    public async Task<ActionResult> GetMovementsAsync([FromQuery] PaginationParams paginationParams)
    {
        var movements = await movementService.GetMovementsAsync(paginationParams.PageNumber, paginationParams.PageSize);
        
        Response.AddPaginationHeader(new PaginationHeader
            (paginationParams.PageNumber, paginationParams.PageSize, movements.TotalPages, movements.TotalCount));
        
        return Ok(movements);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "StockClerk,Admin")]
    
    public async Task<ActionResult> GetMovementAsync(int id)
    {
        var movement = await movementService.GetMovementAsync(id);
        return Ok(movement);
    }

    [HttpPost("{id}/Revert")]
    [Authorize(Roles = "StockClerk,Admin")]
    
    public async Task<ActionResult> RevertMovementAsync(int id)
    {
        var movementReverse = await  movementService.RevertMovementAsync(id);
        return Ok(movementReverse);
    }
    
}