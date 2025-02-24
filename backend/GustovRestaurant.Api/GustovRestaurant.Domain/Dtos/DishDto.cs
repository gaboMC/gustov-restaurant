namespace GustovRestaurant.Domain.Dtos;

public record DishDto(
    int Id,
    string Name,
    decimal Price
    );