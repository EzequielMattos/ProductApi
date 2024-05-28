using Microsoft.EntityFrameworkCore;
using ProductApi.Domain.Repository;
using ProductApi.Infrastructure.Context;

namespace ProductApi.Infrastructure.Repository;

public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
{
    public readonly DataContext _dataContext;

    public BaseRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<T> CreateAsync(T obj)
    {
        await _dataContext.Set<T>().AddAsync(obj);
        await _dataContext.SaveChangesAsync();
        return obj;
    }

    public async Task<T> UpdateAsync(T obj)
    {
        _dataContext.Set<T>().Update(obj);
        await _dataContext.SaveChangesAsync();
        return obj;
    }

    public async Task<T> Delete(T obj)
    {
        _dataContext.Remove(obj);
        await _dataContext.SaveChangesAsync();
        return obj;
    }

    public async Task<IList<T>> GetAllAsync(int skip, int take)
    {
        return await _dataContext.Set<T>().AsNoTracking().Skip(skip).Take(take).ToListAsync();
    }

    public async Task<T> GetByIdAsync(string Id)
    {
        return await _dataContext.Set<T>().FindAsync(Id);
    }
}
