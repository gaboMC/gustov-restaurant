using GustovRestaurant.Application.Services;
using GustovRestaurant.Domain.Models;

namespace GustovRestaurant.Api.EndPoints;

public static class SaleDetailEndPoints
{
    internal static void MapSaleDetailEndPoints(this WebApplication webApp)
    {
        webApp.MapGroup("/sale-detail").WithTags("Sale Detail").MapGroupEndPoint();
    }

    private static void MapGroupEndPoint(this RouteGroupBuilder groupBuilder)
    {
        //Save
        groupBuilder.MapPost(
            "",
            (SaleDetailModel model, SaleDetailService service) =>
            {
                var result = service.Save(model).Result;
                return Results.Json(result, statusCode: (int)result.StatusCode);
            });
        //Update
        groupBuilder.MapPut(
            "{saleDetailId:int}",
            (int saleDetailId, SaleDetailModel model, SaleDetailService service) =>
            {
                var result = service.Update(model).Result;
                return Results.Json(result, statusCode: (int)result.StatusCode);
            });
        //Delete
        groupBuilder.MapDelete(
            "{saleDetailId:int}",
            (int saleDetailId, SaleDetailService service) =>
            {
                var result = service.Delete(saleDetailId).Result;
                return Results.Json(result, statusCode: (int)result.StatusCode);
            });
        //GetById
        groupBuilder.MapGet(
            "/by-id/{saleDetailId:int}",
            (int saleDetailId, SaleDetailService service) =>
            {
                var result = service.GetById(saleDetailId).Result;
                return Results.Json(result, statusCode: (int)result.StatusCode);
            });
        //GetAll
        groupBuilder.MapGet(
            "",
            (SaleDetailService service) =>
            {
                var result = service.GetAll().Result;
                return Results.Json(result, statusCode: (int)result.StatusCode);
            });
    }
}