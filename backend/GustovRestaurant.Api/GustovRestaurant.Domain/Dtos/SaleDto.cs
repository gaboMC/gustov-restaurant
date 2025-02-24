namespace GustovRestaurant.Domain.Dtos;

public record SaleDto(
    int Id,
    DateTime Date,
    decimal Total
    );