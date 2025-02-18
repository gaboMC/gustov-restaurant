using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace GustovRestaurant.Infraestructure.Database.Context;

public class GustovRestaurantDBContextFactory : IDesignTimeDbContextFactory<GustovRestaurantDBContext>
{
    public GustovRestaurantDBContext CreateDbContext(string[] args)
    {
        var basePath = Path.Combine(AppContext.BaseDirectory,"..", "..", "..", "..", "GustovRestaurant.Api");
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json")
            .Build();
        var connectionString = configuration.GetConnectionString("gustovConnection");

        var optionsBuilder = new DbContextOptionsBuilder<GustovRestaurantDBContext>();
        optionsBuilder.UseSqlServer(connectionString);
        return new GustovRestaurantDBContext(optionsBuilder.Options);
    }
}