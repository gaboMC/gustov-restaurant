namespace GustovRestaurant.Domain.Dtos;

public record DailySalesReportDto(
    DateTime SaleDate,
    string DishName,
    int DishQuantity,
    decimal DishPrice,
    decimal DishPriceTotal,
    decimal SalePrice
    );
