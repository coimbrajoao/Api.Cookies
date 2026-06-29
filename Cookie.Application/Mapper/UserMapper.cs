using Cookie.Application.DTOs.User;
using Cookie.Domain.Entities;

namespace Cookie.Application.Mapper;

public static class UserMapper
{
    public static User MapFromDto(UserRequestDto userRequestDto, byte[] senhaHash)
    {
      return   new User(userRequestDto.Username, userRequestDto.UserRole, userRequestDto.Email, senhaHash, senhaHash);
    }

    public static UserResponseDto MapToDto(User user)
    {
        return new UserResponseDto()
        {
            UserId = user.Id,
            Email = user.Email,
            UserName = user.Username,
            UserRole = user.UserRole,
        };
    }
}