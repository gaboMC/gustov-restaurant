namespace GustovRestaurant.Infraestructure.Database.Entities;

public class UserEntity : IIdentifiable
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Role { get; set; }
    public DateTime RegistrationDate { get; set; }
    public ICollection<SaleEntity> Sales { get; set; }
}