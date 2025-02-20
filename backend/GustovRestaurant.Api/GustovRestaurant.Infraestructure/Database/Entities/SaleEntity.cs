using System.Collections;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GustovRestaurant.Infraestructure.Database.Entities;

public class SaleEntity : IIdentifiable
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public decimal Total { get; set; }
    public int UserId { get; set; }
    public UserEntity User { get; set; }
    public ICollection<SaleDetailEntity> SaleDetails { get; set; }
}