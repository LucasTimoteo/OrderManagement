using OrderManagement.Domain.Entities;

namespace OrderManagement.Application.Interfaces.Repositories;
public interface IStockRepository : IRepository<Stock> 
{
    Task<StockProduct?> GetStockProductAsync(int stockId, int productId);
}