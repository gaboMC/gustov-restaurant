namespace GustovRestaurant.Domain.Models;

public class DishModel : ModelBase
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public bool IsActive { get; private set; }

    public DishModel(
        int id,
        string name,
        string description,
        decimal price,
        bool isActive
        ) : base(id)
    {
        Name = name;
        Description = description;
        Price = price;
        IsActive = isActive;
    }
}