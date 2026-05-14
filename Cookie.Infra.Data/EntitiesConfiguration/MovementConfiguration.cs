using Cookie.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cookie.Infra.Data.EntitiesConfiguration;

public class MovementConfiguration : IEntityTypeConfiguration<Movement>
{
    public void Configure(EntityTypeBuilder<Movement> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Quantity)
            .IsRequired();
        builder.Property(x => x.CreatedAt)
            .IsRequired();
        builder.Property(x => x.TypeMovement)
            .IsRequired();
        builder.HasOne(x => x.Stock)
            .WithMany()
            .HasForeignKey(x => x.StockId)
            .OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(x => x.ParentMovement)
            .WithMany()
            .HasForeignKey(x => x.IdMaster)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction);
    }
}