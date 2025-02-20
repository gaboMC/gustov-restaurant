using System.Reflection;
using FluentValidation;
using GustovRestaurant.Application.Services;
using GustovRestaurant.Domain.Repositories;
using GustovRestaurant.Infraestructure.Database.Context;
using GustovRestaurant.Infraestructure.Database.Repositories;
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
        collection.AddValidatorsFromAssembly(Assembly.Load("GustovRestaurant.Application"));
        return collection;
    }
    
    public static IServiceCollection RegisterServices(this IServiceCollection collection)
    {
        //add servicios
        collection.AddTransient<DishService>();
        collection.AddTransient<SaleService>();
        collection.AddTransient<SaleDetailService>();
        return collection;
    }

    public static IServiceCollection RegisterRepositories(this IServiceCollection collection)
    {
        //add repositories
        collection.AddTransient<IDishRepository, DishRepository>();
        collection.AddTransient<ISaleRepository, SaleRepository>();
        collection.AddTransient<ISaleDetaiilRepository, SaleDetailRepository>();
        return collection;
    }
}