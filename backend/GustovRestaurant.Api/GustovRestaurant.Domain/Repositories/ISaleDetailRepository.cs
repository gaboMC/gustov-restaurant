using GustovRestaurant.Domain.Models;

namespace GustovRestaurant.Domain.Repositories;

public interface ISaleDetaiilRepository : IGenericRepository<SaleDetailModel>
{
    Task<List<SaleDetailModel>> GetAllSaleDetailAsync(); 
}