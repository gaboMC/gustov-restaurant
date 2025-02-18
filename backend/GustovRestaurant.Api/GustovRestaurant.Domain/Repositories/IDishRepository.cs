using GustovRestaurant.Domain.Models;

namespace GustovRestaurant.Domain.Repositories;

public interface IDishRepository : IGenericRepository<DishModel>
{
    Task<List<DishModel>> GetAllDishesAsync();   
}