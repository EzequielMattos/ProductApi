using Microsoft.EntityFrameworkCore;
using ProductApi.Domain.Entities;
using ProductApi.Domain.Repository;
using ProductApi.Infrastructure.Context;

namespace ProductApi.Infrastructure.Repository;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(DataContext dataContext) : base(dataContext)
    {
        
    }

    public async Task<IList<Product>> GetByNameAsync(string name)
    {
        return await _dataContext.Set<Product>().Where(x => EF.Functions.Like(x.Nome, $"%{name}%")).ToListAsync();
    }
}
