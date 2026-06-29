using Cookie.Application.DTOs.User;
using Cookie.Application.Exceptions;
using Cookie.Application.Interfaces;
using Cookie.Application.Mapper;
using Cookie.Domain.Interfaces;

namespace Cookie.Application.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    private readonly IUserRepository _userRepository = userRepository;

    public Task<UserResponseDto> AddUserAsync(UserRequestDto userRequestDto)
    {
        throw new NotImplementedException();
    }

    public async Task<UserResponseDto> FindUserByIdAsync(int userId)
    {
        var user = await _userRepository.GetUserById(userId);

        if (user == null)
            throw new NotFoundException("Usuario nao foi encontrado");
        
        return UserMapper.MapToDto(user);
    }

    public async Task<UserResponseDto> FindUserByEmailAsync(string email)
    {
        var user = await _userRepository.GetUserByEmail(email);

        if (user == null)
            throw new NotFoundException("Usuario nao foi encontrado");
        
        return UserMapper.MapToDto(user);
    }

    public Task<UserResponseDto> UpdateUserAsync(UserUpdateDto userUpdateDto)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteUserAsync(int userId)
    {
        var user = await _userRepository.GetUserById(userId);
        if (user == null)
            throw new NotFoundException("Usuario nao foi encontrado");
            
        user.AlterActive(0);
        var userUpdate = await _userRepository.UpdateUser(user);

        return true;
    }
}