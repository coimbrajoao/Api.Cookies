using System.ComponentModel.DataAnnotations;
using Cookie.Domain.Enum;

namespace Cookie.Application.DTOs.User;

public class UserRequestDto
{
    [Required]
    public string Username { get; set; }
    
    [Required]
    public string Password { get; set; }
    
    [Required]
    public string Email { get; set; }
}