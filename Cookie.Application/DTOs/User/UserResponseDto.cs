using Cookie.Domain.Enum;

namespace Cookie.Application.DTOs.User;

public class UserResponseDto
{
    public int UserId { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public Permission UserRole { get; set; }
}