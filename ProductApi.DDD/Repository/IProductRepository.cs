using ProductApi.Domain.Entities;

namespace ProductApi.Domain.Repository;

public interface IProductRepository : IBaseRepository<Product>
{
    Task<IList<Product>> GetByNameAsync(string name);
}
