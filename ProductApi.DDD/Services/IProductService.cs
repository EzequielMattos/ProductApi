using ProductApi.Domain.Entities;

namespace ProductApi.Domain.Services;

public interface IProductService
{
    Task<Product?> CreateAsync(Product product);

    Task<IList<Product>> GetAllAsync(int page = 1, int pageSize = 25);

    Task<IList<Product>> GetByNameAsync(string name);

    Task<Product?> GetByIdAsync(string id);

    Task<Product?> UpdateAsync(Product model, string id);

    Task<Product?> Delete(string id);
}
