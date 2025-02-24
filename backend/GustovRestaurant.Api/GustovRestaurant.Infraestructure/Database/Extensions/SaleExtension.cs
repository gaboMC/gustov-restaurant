using GustovRestaurant.Domain.Dtos;
using GustovRestaurant.Domain.Models;
using GustovRestaurant.Infraestructure.Database.Entities;

namespace GustovRestaurant.Infraestructure.Database.Extensions;

public static class SaleExtension
{
    public static SaleEntity ToEntity(this SaleModel model)
    {
        return new SaleEntity
        {
            Id = model.Id,   
            Date = model.Date,
            Total = model.Total,
            UserId = model.UserId,
        };
    }

    public static SaleModel ToModel(this SaleEntity entity)
    {
        return new SaleModel(
            entity.Id,
            entity.Date,
            entity.Total,
            entity.UserId
        );
    }
    
    public static SaleDto ToDto(this SaleEntity entity)
    {
        return new SaleDto(
            entity.Id,
            entity.Date,
            entity.Total
        );
    }
}