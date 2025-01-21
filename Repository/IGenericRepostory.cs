namespace Talim.Repositories;

public interface IGenericRepository<TEntity> where TEntity : class{
    IQueryable<TEntity> GetAllAsync();
    Task<TEntity?> GetByIdAsync(int id);
    Task<TEntity> AddAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity);
    Task<TEntity> DeleteAsync(TEntity entity);
}