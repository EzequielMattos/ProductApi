namespace ProductApi.Domain.Repository;

public interface IBaseRepository<T> where T : class
{
    Task<T> CreateAsync(T obj);
    Task<T> UpdateAsync(T obj);
    Task<T> Delete(T obj);
    Task<IList<T>> GetAllAsync(int skip, int take);
    Task<T> GetByIdAsync(string id);
}
