using Cookie.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cookie.Infra.Data.EntitiesConfiguration;

public class StockConfiguration : IEntityTypeConfiguration<Stock>
{
    public void Configure(EntityTypeBuilder<Stock> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Quantity)
            .IsRequired();
        builder.Property(c => c.Price)
            .IsRequired();
        builder.Property(c => c.CreatedAt)
            .IsRequired();
        builder.HasOne(c => c.Product)
            .WithMany(c => c.Stocks)
            .HasForeignKey(c => c.ProductId)
            .OnDelete(DeleteBehavior.NoAction);;
    }
}