using GustovRestaurant.Infraestructure.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace GustovRestaurant.Infraestructure.Database.Context;

public class GustovRestaurantDBContext:DbContext
{
    public DbSet<DishEntity> Dishes { get; set; }
    public DbSet<SaleEntity> Sales { get; set; }
    public DbSet<SaleDetailEntity> SaleDetails { get; set; }
    public GustovRestaurantDBContext(DbContextOptions<GustovRestaurantDBContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new DishConfiguration());
        builder.ApplyConfiguration(new SaleConfiguration());
        builder.ApplyConfiguration(new SaleDetailConfiguration());
        base.OnModelCreating(builder);
    }
}