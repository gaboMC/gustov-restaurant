using GustovRestaurant.Domain.Repositories;
using GustovRestaurant.Infraestructure.Database.Context;
using GustovRestaurant.Infraestructure.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace GustovRestaurant.Infraestructure.Database.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IIdentifiable
{
    private readonly GustovRestaurantDBContext _dbContext;
    private readonly DbSet<TEntity> _dbSet;

    protected GenericRepository(GustovRestaurantDBContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<TEntity>();
    }

    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        var entityEntry = await _dbSet.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entityEntry.Entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        var entityEntry = _dbSet.Update(entity);
        await _dbContext.SaveChangesAsync();
        return entityEntry.Entity;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var del = await _dbSet.FindAsync(id);
        if (del is null) return false;
        
        _dbSet.Remove(del);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<TEntity?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }
}