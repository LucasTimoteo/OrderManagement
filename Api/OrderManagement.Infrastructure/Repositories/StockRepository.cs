using Microsoft.EntityFrameworkCore;
using OrderManagement.Application.Interfaces.Repositories;
using OrderManagement.Domain.Entities;
using OrderManagement.Infrastructure.Data;

namespace OrderManagement.Infrastructure.Repositories;

public class StockRepository : Repository<Stock>, IStockRepository
{
    public StockRepository(AppDbContext context) : base(context) { }

    public async Task<StockProduct?> GetStockProductAsync(int stockId, int productId) =>
       await _context.Set<StockProduct>()
           .FirstOrDefaultAsync(sp => sp.StockId == stockId && sp.ProductId == productId);
}