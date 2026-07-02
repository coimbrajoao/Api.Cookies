using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Cookie.Domain.Account;
using Cookie.Domain.Entities;
using Cookie.Domain.Enum;
using Cookie.Domain.Interfaces;
using Cookie.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Cookie.Infra.Data.Identity;

public class AuthenticateService(IConfiguration _configuration, ApplicationDbContext _context) : IAuthenticate
{

    public string GenerateToken(int userId, string email, Permission permission)
    {
        var claims = new[]
        {
            new Claim("id", userId.ToString()),
            new Claim(ClaimTypes.Email, email.ToLower()),
            new Claim("role", permission.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
        var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

        JwtSecurityToken token = new JwtSecurityToken(
            issuer:_configuration["Jwt:Issuer"],
            audience:_configuration["Jwt:Audience"],
            claims: claims,
            expires:DateTime.Now.AddHours(8),
            signingCredentials: credentials);
        
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        return await _context.User.FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower() && x.Active == 1);
    }

    public async Task<bool> Authenticate(string email, string password)
    {
        var user = await _context.User.FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower());
        if(user == null || user.Active ==0)
            return false;


        using var hmac = new HMACSHA512(user.PasswordSalt);
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        
        for (int i = 0; i < computedHash.Length; i++)
        {
            if(computedHash[i] != user.PasswordHash[i])
                return false;
        }
        return true;
    }
}