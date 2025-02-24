using GustovRestaurant.Domain.Dtos;
using GustovRestaurant.Domain.Models;
using GustovRestaurant.Infraestructure.Database.Entities;

namespace GustovRestaurant.Infraestructure.Database.Extensions;

public static class SaleDetailExtension
{
    public static SaleDetailEntity ToEntity(this SaleDetailModel model)
    {
        return new SaleDetailEntity
        {
            Id = model.Id,
            SaleId = model.SaleId,
            DishId = model.DishId,
            Quantity = model.Quantity,
            Price = model.Price,
        };
    }

    public static SaleDetailModel ToModel(this SaleDetailEntity entity)
    {
        return new SaleDetailModel(
            entity.Id,
            entity.SaleId,
            entity.DishId,
            entity.Quantity,
            entity.Price
            );
    }

    public static SaleDetailDto ToDto(this SaleDetailEntity entity)
    {
        return new SaleDetailDto(
            entity.Id,
            entity.SaleId,
            null,
            entity.DishId,
            null,
            entity.Quantity,
            entity.Price
            );
    }
}