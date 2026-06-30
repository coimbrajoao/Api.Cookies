using Cookie.Application.DTOs.User;
using Cookie.Domain.Entities;
using Cookie.Domain.Enum;

namespace Cookie.Application.Mapper;

public static class UserMapper
{
    public static User MapFromDto(UserRequestDto userRequestDto, byte[] passwordHash, byte[] passwordSalt, Permission role)
    {
      return new User(userRequestDto.Username, role, userRequestDto.Email, passwordHash, passwordSalt);
    }

    public static UserResponseDto MapToDto(User user)
    {
        return new UserResponseDto()
        {
            UserId = user.Id,
            Email = user.Email,
            UserName = user.UserName,
            UserRole = user.UserRole,
        };
    }
}