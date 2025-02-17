using Microsoft.EntityFrameworkCore;

namespace GustovRestaurant.Infraestructure.Database.Context;

public class GustovRestaurantDBContext:DbContext
{
    public GustovRestaurantDBContext(DbContextOptions<GustovRestaurantDBContext> options) : base(options) {}
}