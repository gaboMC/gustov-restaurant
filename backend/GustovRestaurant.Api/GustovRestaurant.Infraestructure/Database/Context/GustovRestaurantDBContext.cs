using GustovRestaurant.Infraestructure.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace GustovRestaurant.Infraestructure.Database.Context;

public class GustovRestaurantDBContext:DbContext
{
    public DbSet<DishEntity> Dishes { get; set; }
    public DbSet<SaleEntity> Sales { get; set; }
    public GustovRestaurantDBContext(DbContextOptions<GustovRestaurantDBContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new DishConfiguration());
        builder.ApplyConfiguration(new SaleConfiguration());
        base.OnModelCreating(builder);
    }
}