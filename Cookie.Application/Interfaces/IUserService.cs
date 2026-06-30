using Cookie.Application.DTOs.User;
using Cookie.Domain.Entities;

namespace Cookie.Application.Interfaces;

public interface IUserService
{
    Task<UserResponseDto> AddUserAsync(UserRequestDto userRequestDto);
    Task<UserResponseDto> FindUserByIdAsync(int userId);
    Task<UserResponseDto> FindUserByEmailAsync(string email);
    Task<UserResponseDto> UpdateUserAsync(UserUpdateDto userUpdateDto, int userId);
    Task<bool> DeleteUserAsync(int userId);
}