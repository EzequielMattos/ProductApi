using ProductApi.Domain.Entities;
using ProductApi.Domain.Repository;
using ProductApi.Domain.Services;

namespace ProductApi.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;
    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Product?> CreateAsync(Product product)
    {
        try
        {
            if (product.Preco < 0)
                return null;

            await _repository.CreateAsync(product);

            return product;
        }
        catch
        {
            throw;
        }
    }

    public async Task<IList<Product>> GetAllAsync(int page = 1, int pageSize = 25)
    {
        try
        {
            var skip = (page - 1) * pageSize;
            var take = pageSize;

            var produto = await _repository.GetAllAsync(skip, take);

            return produto;
        }
        catch
        {
            throw;
        }
    }

    public async Task<Product?> GetByIdAsync(string id)
    {
        try
        {
            var product = await _repository.GetByIdAsync(id);

            if (product == null)
                return null;

            return product;
        }
        catch
        {
            throw;
        }
    }

    public async Task<Product?> UpdateAsync(Product model, string id)
    {
        try
        {
            var product = await _repository.GetByIdAsync(id);

            if (product == null)
                return null;

            product.Nome = model.Nome;
            product.Preco = model.Preco;
            product.Quantidade = model.Quantidade;
            product.Estoque = model.Estoque;

            return await _repository.UpdateAsync(product);
        }
        catch
        {
            throw;
        }
    }

    public async Task<Product?> Delete(string id)
    {
        try
        {
            var product = await _repository.GetByIdAsync(id);

            if (product == null)
                return null;

            return await _repository.Delete(product);
        }
        catch
        {
            throw;
        }
    }

    public async Task<IList<Product>> GetByNameAsync(string name)
    {
        try
        {
            var produto = await _repository.GetByNameAsync(name);

            return produto;
        }
        catch
        {
            throw;
        }
    }
}
