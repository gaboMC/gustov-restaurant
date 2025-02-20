namespace GustovRestaurant.Infraestructure.Database.Entities;

public class SaleDetailEntity : IIdentifiable
{
    public int Id { get; set; }
    public int SaleId { get; set; }
    public int DishId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public SaleEntity Sale { get; set; }
    public DishEntity Dish { get; set; }
}