using Cookie.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cookie.Infra.Data.EntitiesConfiguration;

public class ProductConfiguration: IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(c => c.Description)
            .IsRequired()
            .HasMaxLength(500);
        builder.Property(c => c.Flavor)
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(c => c.Price)
            .IsRequired();
    }
}