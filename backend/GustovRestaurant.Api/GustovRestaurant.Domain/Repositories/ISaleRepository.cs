using GustovRestaurant.Domain.Dtos;
using GustovRestaurant.Domain.Models;

namespace GustovRestaurant.Domain.Repositories;

public interface ISaleRepository : IGenericRepository<SaleModel>
{
    Task<List<SaleDto>> GetSalesByDateAsync(DateTime filterDate); 
}