using Cookie.Application.DTOs.User;
using Cookie.Application.Exceptions;
using Cookie.Application.Interfaces;
using Cookie.Application.Mapper;
using Cookie.Domain.Interfaces;
using System.Security.Cryptography;
using System.Text;
using Cookie.Domain.Enum;
using Microsoft.Extensions.Configuration;

namespace Cookie.Application.Services;

public class UserService(IUserRepository userRepository, IUnitOfWork uow) : IUserService
{

    public async Task<UserResponseDto> AddUserAsync(UserRequestDto userRequestDto)
    {
        using var hmc = new HMACSHA512();
        byte[] passwordHash = hmc.ComputeHash(Encoding.UTF8.GetBytes(userRequestDto.Password));
        byte[] passwordSalt = hmc.Key;

        var userExist = await userRepository.ExistsAsync();
        
        var role= !userExist ? Permission.Admin : Permission.StockClerk;
        
        var user = await userRepository.AddAsync(UserMapper.MapFromDto(userRequestDto,  passwordHash, passwordSalt, role));
        await  uow.Save();
        return UserMapper.MapToDto(user);
    }

    public async Task<UserResponseDto> FindUserByIdAsync(int userId)
    {
        var user = await userRepository.GetUserById(userId);

        return user == null ? throw new NotFoundException("Usuario nao foi encontrado") : UserMapper.MapToDto(user);
    }

    public async Task<UserResponseDto> FindUserByEmailAsync(string email)
    {
        var user = await userRepository.GetUserByEmail(email);

        return user == null ? throw new NotFoundException("Usuario nao foi encontrado") : UserMapper.MapToDto(user);
    }

    public async Task<UserResponseDto> UpdateUserAsync(UserUpdateDto userUpdateDto, int userId)
    {
        var user  = await userRepository.GetUserById(userId);
        
        if (user == null)
            throw new NotFoundException("Usuario nao foi encontrado");
        
        if(userUpdateDto.Email != null && userUpdateDto.Email != user.Email)
            user.AlterEmail(userUpdateDto.Email);

        if (userUpdateDto.UserName != null && userUpdateDto.UserName != user.UserName)
            user.AlterUserName(userUpdateDto.UserName);
        
        await userRepository.UpdateUser(user);
        await uow.Save();
        
        return UserMapper.MapToDto(user);
    }

    public async Task<bool> DeleteUserAsync(int userId)
    {
        var user = await userRepository.GetUserById(userId);
        if (user == null)
            throw new NotFoundException("Usuario nao foi encontrado");
            
        user.AlterActive(0);
        var userUpdate = await userRepository.UpdateUser(user);
        await uow.Save();
        return userUpdate;
    }
}