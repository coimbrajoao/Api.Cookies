using Cookie.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;

namespace Cookie.Infra.Data.EntitiesConfiguration;

public class StockConfiguration : IEntityTypeConfiguration<Stock>
{
    public void Configure(EntityTypeBuilder<Stock> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Quantity)
            .IsRequired();
        builder.Property(c => c.UnitPrice)
            .IsRequired();
        builder.Property(c => c.CreatedAt)
            .IsRequired();
        builder.Property(c => c.DueDate)
            .IsRequired();
        builder.HasOne(c => c.Product)
            .WithMany(c => c.Stocks)
            .HasForeignKey(c => c.ProductId)
            .OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(c => c.User)
            .WithMany()
            .HasForeignKey(u => u.UserId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}