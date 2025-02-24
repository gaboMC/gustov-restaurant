namespace GustovRestaurant.Domain.Models;

public class SaleModel : ModelBase
{
    public DateTime Date { get; private set; }
    public decimal Total { get; private set; }
    public int UserId { get; private set; }
    public List<SaleDetailModel> SaleDetails { get; private set; }

    public SaleModel(
        int id,
        DateTime date,
        decimal total,
        int userId,
        List<SaleDetailModel>? saleDetails = null
        ) : base(id)
    {
        Date = date;
        Total = total;
        UserId = userId;
        SaleDetails = saleDetails ?? new List<SaleDetailModel>();
    }
}