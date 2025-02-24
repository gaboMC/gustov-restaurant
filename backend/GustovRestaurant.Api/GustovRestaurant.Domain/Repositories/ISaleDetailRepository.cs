using GustovRestaurant.Domain.Dtos;
using GustovRestaurant.Domain.Models;

namespace GustovRestaurant.Domain.Repositories;

public interface ISaleDetailRepository : IGenericRepository<SaleDetailModel>
{
    Task<bool> SaveRange(List<SaleDetailModel> model);
    Task<List<SaleDetailDto>> GetSaleDetailsBySaleIdAsync(List<int> saleIds); 
}