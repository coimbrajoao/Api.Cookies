using Cookie.Application.DTOs;
using Cookie.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cookie.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MovementController(IMovementService movementService) : Controller
{

    [HttpPost]
    public async Task<ActionResult> AddMovementAsync(MovementRequestDto movementRequestDto)
    {
        var movement = await movementService.AddMovementAsync(movementRequestDto);
        return Ok(movement);
    }

    [HttpGet]
    public async Task<ActionResult> GetMovementsAsync()
    {
        var movements = await movementService.GetMovementsAsync();
        return Ok(movements);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetMovementAsync(int id)
    {
        var movement = await movementService.GetMovementAsync(id);
        return Ok(movement);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteMovementAsync(int id)
    {
        var deleted = await movementService.DeleteMovementAsync(id);
        return deleted ? Ok() : BadRequest();
    }
    
}