using GustovRestaurant.Domain.Dtos;
using GustovRestaurant.Domain.Models;
using GustovRestaurant.Domain.Repositories;
using GustovRestaurant.Infraestructure.Database.Context;
using GustovRestaurant.Infraestructure.Database.Entities;
using GustovRestaurant.Infraestructure.Database.Extensions;
using Microsoft.EntityFrameworkCore;

namespace GustovRestaurant.Infraestructure.Database.Repositories;

public class DishRepository : GenericRepository<DishEntity>, IDishRepository
{
    private readonly GustovRestaurantDBContext _dbContext;
    public DishRepository(GustovRestaurantDBContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<DishModel> CreateAsync(DishModel model)
    {
        var entity = model.ToEntity();
        var result = await CreateAsync(entity);
        return result.ToModel();
    }

    public async Task<DishModel> UpdateAsync(DishModel model)
    {
        var entity = model.ToEntity();
        var result = await UpdateAsync(entity);
        return result.ToModel();
    }

    public async Task<DishModel?> GetByIdAsync(int id)
    {
        var entity = await base.GetByIdAsync(id);
        return entity?.ToModel();
    }

    public async Task<DishModel?> DeleteSoftAsync(int id)
    {
        var entity = await _dbContext.Dishes.FindAsync(id);
        if (entity != null)
        {
            entity.IsActive = !entity.IsActive; 
            await UpdateAsync(entity);
            return entity.ToModel();
        }
        return null;
    }

    public async Task<List<DishModel>> GetAllDishesAsync()
    {
        var result = await _dbContext.Dishes
            .Where(d => d.IsActive == true)
            .ToListAsync();
        return result.Select(d => d.ToModel()).ToList();
    }

    public async Task<List<DishDto>> GetAllDishDtosAsync()
    {
        var result = await _dbContext.Dishes.ToListAsync();
        return result.Select(d => d.ToDto()).ToList();
    }
}