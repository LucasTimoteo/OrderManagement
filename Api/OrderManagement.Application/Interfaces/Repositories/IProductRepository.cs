using OrderManagement.Domain.Entities;

namespace OrderManagement.Application.Interfaces.Repositories;
public interface IProductRepository : IRepository<Product> 
{
    Task<List<Product>> GetWithPromotionsAndStocksAsync(IEnumerable<int> ids);
}
