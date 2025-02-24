namespace GustovRestaurant.Domain.Dtos;

public record SaleDetailDto(
    int Id,
    int SaleId,
    SaleDto? Sale,
    int DishId,
    DishDto? Dish,
    int Quantity,
    decimal Price
    );