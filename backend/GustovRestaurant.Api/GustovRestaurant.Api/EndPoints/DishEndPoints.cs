using GustovRestaurant.Application.Services;
using GustovRestaurant.Domain.Models;

namespace GustovRestaurant.Api.EndPoints;

public static class DishEndPoints
{
    internal static void MapDishEndPoints(this WebApplication webApp)
    {
        webApp.MapGroup("/dish").WithTags("Dish").MapGroupEndPoint();
    }

    private static void MapGroupEndPoint(this RouteGroupBuilder groupBuilder)
    {
        //Save
        groupBuilder.MapPost(
            "",
            (DishModel model, DishService service) =>
            {
                var result = service.Save(model).Result;
                return Results.Json(result, statusCode: (int)result.StatusCode);
            });
        //Update
        groupBuilder.MapPut(
            "{dishId:int}",
            (int dishId, DishModel model, DishService service) =>
            {
                var result = service.Update(model).Result;
                return Results.Json(result, statusCode: (int)result.StatusCode);
            });
        //Delete
        groupBuilder.MapDelete(
            "{dishId:int}",
            (int dishId, DishService service) =>
            {
                var result = service.Delete(dishId).Result;
                return Results.Json(result, statusCode: (int)result.StatusCode);
            });
        //GetById
        groupBuilder.MapGet(
            "/by-id/{dishId:int}",
            (int dishId, DishService service) =>
            {
                var result = service.GetById(dishId).Result;
                return Results.Json(result, statusCode: (int)result.StatusCode);
            });
        //GetAll
        groupBuilder.MapGet(
            "",
            (DishService service) =>
            {
                var result = service.GetAll().Result;
                return Results.Json(result, statusCode: (int)result.StatusCode);
            });
    }
}