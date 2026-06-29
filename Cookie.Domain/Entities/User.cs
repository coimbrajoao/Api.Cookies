using Cookie.Domain.Enum;

namespace Cookie.Domain.Entities;

public class User
{
    public int Id { get; }
    public string Username { get; private set; }
    public byte[] PasswordHash { get; private set; }
    public byte[] PasswordSalt { get; private set; }
    public string Email { get; private set; }
    
    public DateTime CreatedAt { get; private set; } =  DateTime.Now;
    
    public Permission UserRole { get; private set; }
    
    public User(string username, Permission userRole, string email, byte[] passwordHash, byte[] passwordSalt)
    {
        Username = username;
        Email = email;
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
        UserRole = userRole;
    }
}