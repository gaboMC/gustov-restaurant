namespace GustovRestaurant.Domain.Repositories;

public interface IGenericRepository<TEntity> where TEntity : class
{
    Task<TEntity> CreateAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity);
    Task<bool> DeleteAsync(int id);
    Task<TEntity?> GetByIdAsync(int id);
    
}