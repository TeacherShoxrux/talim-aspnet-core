using Talim.Data;

namespace Talim.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;
    public GenericRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<T> AddAsync(T entity)
    {
        var entry = await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entry.Entity;
    }

    public async Task<T> DeleteAsync(T entity)
    {
        var entry = _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
        return entry.Entity;
    }

     public IQueryable<T> GetAllAsync()=> 
            _context.Set<T>();

      public async Task<T?> GetByIdAsync(int id)=> 
            await _context.Set<T>().FindAsync(id);


    public async Task<T> UpdateAsync(T entity)
    {
        var entry = _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
        return entry.Entity;
    }
}