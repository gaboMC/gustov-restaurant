using GustovRestaurant.Application.Services;
using GustovRestaurant.Domain.Models;

namespace GustovRestaurant.Api.EndPoints;

public static class SaleEndPoints
{
    internal static void MapSaleEndPoints(this WebApplication webApp)
    {
        webApp.MapGroup("/sale").WithTags("Sale").MapGroupEndPoint();
    }

    private static void MapGroupEndPoint(this RouteGroupBuilder groupBuilder)
    {
        //Save
        groupBuilder.MapPost(
            "",
            (SaleModel model, SaleService service) =>
            {
                var result = service.Save(model).Result;
                return Results.Json(result, statusCode: (int)result.StatusCode);
            });
        //Update
        groupBuilder.MapPut(
            "{saleId:int}",
            (int saleId, SaleModel model, SaleService service) =>
            {
                var result = service.Update(model).Result;
                return Results.Json(result, statusCode: (int)result.StatusCode);
            });
        //Delete
        groupBuilder.MapDelete(
            "{saleId:int}",
            (int saleId, SaleService service) =>
            {
                var result = service.Delete(saleId).Result;
                return Results.Json(result, statusCode: (int)result.StatusCode);
            });
        //GetById
        groupBuilder.MapGet(
            "/by-id/{saleId:int}",
            (int saleId, SaleService service) =>
            {
                var result = service.GetById(saleId).Result;
                return Results.Json(result, statusCode: (int)result.StatusCode);
            });
        //GetAll
        groupBuilder.MapGet(
            "",
            (SaleService service) =>
            {
                var result = service.GetAll().Result;
                return Results.Json(result, statusCode: (int)result.StatusCode);
            });
    }
}