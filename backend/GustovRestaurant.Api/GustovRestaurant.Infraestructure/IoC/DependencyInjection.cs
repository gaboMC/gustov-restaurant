using GustovRestaurant.Infraestructure.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GustovRestaurant.Infraestructure.IoC;

public static class DependencyInjection
{
    public static IServiceCollection RegisterDataBase(this IServiceCollection collection, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("gustovConnection");
        collection.AddDbContext<GustovRestaurantDBContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });
        return collection;
    }
    
    public static IServiceCollection RegisterLibraries(this IServiceCollection collection)
    {
        //add fluentValidator
        return collection;
    }
    
    public static IServiceCollection RegisterServices(this IServiceCollection collection)
    {
        //add servicios
        return collection;
    }

    public static IServiceCollection RegisterRepositories(this IServiceCollection collection)
    {
        //add repositories
        return collection;
    }
}