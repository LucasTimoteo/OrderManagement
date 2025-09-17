using Microsoft.EntityFrameworkCore;
using OrderManagement.Application.Interfaces.Repositories;
using OrderManagement.Domain.Entities;
using OrderManagement.Infrastructure.Data;

namespace OrderManagement.Infrastructure.Repositories;

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context) { }

    public async Task<List<Product>> GetWithPromotionsAndStocksAsync(IEnumerable<int> ids) =>
        await _dbSet
            .Include(p => p.ProductPromotions)
                .ThenInclude(pp => pp.Promotion)
            .Include(p => p.StockProducts)
            .Where(p => ids.Contains(p.Id) && p.IsActive)
            .ToListAsync();
}
