using OrderManagement.Domain.Entities;

namespace OrderManagement.Application.Interfaces.Repositories;

public interface IStockProductRepository
{
    Task<StockProduct?> GetAsync(int stockId, int productId);
    Task<IEnumerable<StockProduct>> GetByProductIdAsync(int productId);
    Task<IEnumerable<StockProduct>> GetByStockIdAsync(int stockId);
    Task AddAsync(StockProduct entity);
    void Update(StockProduct entity);
    void Remove(StockProduct entity);
    Task SaveChangesAsync();
    Task<bool> HasAvailableAsync(int stockId, int productId, int requestedQty);
}
