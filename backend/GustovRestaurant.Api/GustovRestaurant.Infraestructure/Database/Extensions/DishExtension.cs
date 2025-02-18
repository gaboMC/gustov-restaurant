using GustovRestaurant.Domain.Models;
using GustovRestaurant.Infraestructure.Database.Entities;

namespace GustovRestaurant.Infraestructure.Database.Extensions;

public static class DishExtension
{
    public static DishEntity ToEntity(this DishModel model)
    {
        return new DishEntity
        {
            Id = model.Id,
            Name = model.Name,
            Description = model.Description,
            Price = model.Price,
            IsActive = model.IsActive
        };
    }

    public static DishModel ToModel(this DishEntity entity)
    {
        return new DishModel(
            entity.Id,
            entity.Name,
            entity.Description,
            entity.Price,
            entity.IsActive
        );
    }
}