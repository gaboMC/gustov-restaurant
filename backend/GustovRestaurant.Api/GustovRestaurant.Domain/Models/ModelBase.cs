namespace GustovRestaurant.Domain.Models;

public class ModelBase
{
    public int Id { get; set; }
    
    protected ModelBase(int id) => Id = id;
}