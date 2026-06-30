using Cookie.Domain.Enum;

namespace Cookie.Domain.Entities;

public class User
{
    public int Id { get; }
    public string UserName { get; private set; }
    public byte[] PasswordHash { get; private set; }
    public byte[] PasswordSalt { get; private set; }
    public string Email { get; private set; }
    
    public int Active {get; private set;}
    public DateTime CreatedAt { get; private set; } =  DateTime.Now;
    
    public Permission UserRole { get; private set; }
    
    public User(){}
    public User(string username, Permission userRole, string email, byte[] passwordHash, byte[] passwordSalt)
    {
        UserName = username;
        Email = email;
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
        UserRole = userRole;
        Active = 1;
    }
    
    public void AlterActive(int active)
    {
        Active = active;
    }

    public void AlterUserName(string UserNameUpdate)
    {
        if (string.IsNullOrEmpty(UserNameUpdate))
        {
            throw new ArgumentNullException("Usario invalido, por favor digite novamente");
        }
        
        this.UserName = UserNameUpdate;
    }

    public void AlterEmail(string Email)
    {
        if (string.IsNullOrEmpty(Email))
        {
            throw new ArgumentNullException("Email invalido, por favor digite novamente");
            
        }
        
        this.Email = Email;
    }

    public void AlterUserRole(Permission userRole)
    {
        UserRole = userRole;
    }
}