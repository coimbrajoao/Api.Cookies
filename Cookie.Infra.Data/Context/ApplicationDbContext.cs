using Cookie.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cookie.Infra.Data.Context;

public class ApplicationDbContext : DbContext
{
   public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :  base(options){}
   
   public DbSet<Product> Product { get; set; }
   public DbSet<Stock> Stock { get; set; }
   public DbSet<Movement> Movement { get; set; }
   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
      base.OnModelCreating(modelBuilder);
      modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
   }
}