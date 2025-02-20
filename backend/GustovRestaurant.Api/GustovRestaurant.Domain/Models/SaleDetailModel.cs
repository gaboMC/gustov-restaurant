namespace GustovRestaurant.Domain.Models;

public class SaleDetailModel : ModelBase
{
    public int SaleId { get; set; }
    public int DishId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    public SaleDetailModel(
        int id,
        int saleId,
        int dishId,
        int quantity,
        decimal price
        ) : base(id)
    {
        SaleId = saleId;
        DishId = dishId;
        Quantity = quantity;
        Price = price;
    }
}