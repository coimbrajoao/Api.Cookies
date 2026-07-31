using Cookie.Application.DTOs.User;
using Cookie.Application.Interfaces;
using Cookie.Domain.Account;
using Microsoft.AspNetCore.Mvc;

namespace Cookie.API.Controllers;

[ApiController]
public class LoginController(IUserService _userService, IAuthenticate _authenticate) : Controller
{

    [HttpPost]
    [Route("Register")]
    public async Task<ActionResult> Register(UserRequestDto request)
    {
        var user = await _userService.AddUserAsync(request);
        var token = _authenticate.GenerateToken(user.UserId, user.Email, user.UserRole);
        return Ok(new{token = token, Name = user.UserName});
    }

    [HttpPost]
    [Route("Login")]
    public async Task<ActionResult> Login(UserLoginDto request)
    {
        var user = await _authenticate.GetUserByEmail(request.Email);
        if (user == null)
            return BadRequest("Usuario nao encontrado");

        var userValidat = await _authenticate.Authenticate(request.Email, request.Password);
        if(!userValidat)
            return Unauthorized("Usuario ou senha invalido");
        
        var token = _authenticate.GenerateToken(user.Id, user.Email, user.UserRole);

        return Ok(new { token = token });
    }
}
