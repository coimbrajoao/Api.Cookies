using Cookie.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cookie.Infra.Data.EntitiesConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.UserName).HasMaxLength(128).IsRequired();
        builder.Property(x => x.Email).HasMaxLength(128).IsRequired();
        builder.Property(x => x.PasswordHash).HasMaxLength(128).IsRequired();
        builder.Property(x => x.PasswordSalt).HasMaxLength(128).IsRequired();
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.UserRole).IsRequired();
    }
}