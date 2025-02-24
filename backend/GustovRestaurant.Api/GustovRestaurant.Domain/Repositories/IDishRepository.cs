using GustovRestaurant.Domain.Dtos;
using GustovRestaurant.Domain.Models;

namespace GustovRestaurant.Domain.Repositories;

public interface IDishRepository : IGenericRepository<DishModel>
{
    Task<DishModel?> DeleteSoftAsync(int id);
    Task<List<DishModel>> GetAllDishesAsync();
    Task<List<DishDto>> GetAllDishDtosAsync(); 
}