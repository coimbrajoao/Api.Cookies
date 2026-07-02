using Cookie.Application.DTOs.User;
using Cookie.Application.Interfaces;
using Cookie.Domain.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cookie.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController(IUserService userService) : Controller
{

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> CreateUser(UserRequestDto request)
    {
        var response = await userService.AddUserAsync(request);
        if (response == null)
            return BadRequest("Não foi possivel criar o usuario");
        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult> GetUserByEmail(string email)
    {
        var response = await userService.FindUserByEmailAsync(email);
        if (response == null)
            return BadRequest("Usuario não encontrado");
        return Ok(response);
    }

    [HttpGet]
    [Route("{Id:int}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> GetUserById(int Id)
    {
        var response = await userService.FindUserByIdAsync(Id);
        if (response == null)
            return BadRequest("Usuario não encontrado");
        return Ok(response);
    }

    [HttpDelete]
    [Route("{Id:int}")]
    [Authorize(Roles = nameof(Permission.Admin))]
    public async Task<ActionResult> DeleteUser(int Id)
    {
        var response = await userService.DeleteUserAsync(Id);
        
        return Ok(response);
    }

    [HttpPut]
    [Route("{Id:int}")]
    [Authorize(Roles = nameof(Permission.Admin))]
    public async Task<ActionResult> UpdateUser(int Id, UserUpdateDto request)
    {
        var response = await userService.UpdateUserAsync(request, Id);
        return Ok(response);
    }
}