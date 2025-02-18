using Microsoft.EntityFrameworkCore;

namespace GustovRestaurant.Api.Infrastructure.Database.EntityFramework.Context;

public class GustovRestaurantDbContext: DbContext
{
    public GustovRestaurantDbContext(DbContextOptions<GustovRestaurantDbContext> options) : base(options){}
}