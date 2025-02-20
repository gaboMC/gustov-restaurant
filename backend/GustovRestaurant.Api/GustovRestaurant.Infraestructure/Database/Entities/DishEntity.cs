namespace GustovRestaurant.Infraestructure.Database.Entities;

public class DishEntity : IIdentifiable
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public bool IsActive { get; set; }
    
    public ICollection<SaleDetailEntity> SaleDetails { get; set; }
}