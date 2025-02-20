using GustovRestaurant.Domain.Models;
using GustovRestaurant.Domain.Repositories;
using GustovRestaurant.Infraestructure.Database.Context;
using GustovRestaurant.Infraestructure.Database.Entities;
using GustovRestaurant.Infraestructure.Database.Extensions;
using Microsoft.EntityFrameworkCore;

namespace GustovRestaurant.Infraestructure.Database.Repositories;

public class SaleDetailRepository : GenericRepository<SaleDetailEntity>, ISaleDetaiilRepository
{
    private readonly GustovRestaurantDBContext _dbContext;
    public SaleDetailRepository(GustovRestaurantDBContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<SaleDetailModel> CreateAsync(SaleDetailModel model)
    {
        var entity = model.ToEntity();
        var result = await CreateAsync(entity);
        return result.ToModel();
    }

    public async Task<SaleDetailModel> UpdateAsync(SaleDetailModel model)
    {
        var entity = model.ToEntity();
        var result = await UpdateAsync(entity);
        return result.ToModel();
    }

    public async Task<SaleDetailModel?> GetByIdAsync(int id)
    {
        var entity = await base.GetByIdAsync(id);
        return entity?.ToModel();
    }

    public async Task<List<SaleDetailModel>> GetAllSaleDetailAsync()
    {
        var result = await _dbContext.SaleDetails.ToListAsync();
        return result.Select(s => s.ToModel()).ToList();
    }
}