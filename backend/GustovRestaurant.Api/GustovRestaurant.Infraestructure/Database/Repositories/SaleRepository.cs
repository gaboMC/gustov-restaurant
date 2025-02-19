using GustovRestaurant.Domain.Models;
using GustovRestaurant.Domain.Repositories;
using GustovRestaurant.Infraestructure.Database.Context;
using GustovRestaurant.Infraestructure.Database.Entities;
using GustovRestaurant.Infraestructure.Database.Extensions;
using Microsoft.EntityFrameworkCore;

namespace GustovRestaurant.Infraestructure.Database.Repositories;

public class SaleRepository : GenericRepository<SaleEntity>, ISaleRepository
{
    private readonly GustovRestaurantDBContext _dbContext;
    
    public SaleRepository(GustovRestaurantDBContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<SaleModel> CreateAsync(SaleModel model)
    {
        var entity = model.ToEntity();
        var result = await CreateAsync(entity);
        return result.ToModel();
    }

    public async Task<SaleModel> UpdateAsync(SaleModel model)
    {
        var entity = model.ToEntity();
        var result = await UpdateAsync(entity);
        return result.ToModel();
    }

    public async Task<SaleModel?> GetByIdAsync(int id)
    {
        var entity = await base.GetByIdAsync(id);
        return entity?.ToModel();
    }

    public async Task<List<SaleModel>> GetAllSalesAsync()
    {
        var result = await _dbContext.Sales.ToListAsync();
        return result.Select(s => s.ToModel()).ToList();

    }
}