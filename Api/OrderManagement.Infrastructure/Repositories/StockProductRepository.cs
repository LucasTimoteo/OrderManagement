using Microsoft.EntityFrameworkCore;
using OrderManagement.Application.Interfaces.Repositories;
using OrderManagement.Domain.Entities;
using OrderManagement.Infrastructure.Data;

namespace OrderManagement.Infrastructure.Repositories;
public class StockProductRepository : IStockProductRepository
{
    private readonly AppDbContext _context;
    private readonly DbSet<StockProduct> _dbSet;

    public StockProductRepository(AppDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<StockProduct>();
    }

    public async Task<StockProduct?> GetAsync(int stockId, int productId)
    {
        return await _dbSet
            .Include(sp => sp.Stock)
            .Include(sp => sp.Product)
            .FirstOrDefaultAsync(sp => sp.StockId == stockId && sp.ProductId == productId);
    }

    public async Task<IEnumerable<StockProduct>> GetByProductIdAsync(int productId)
    {
        return await _dbSet
            .Where(sp => sp.ProductId == productId)
            .Include(sp => sp.Stock)
            .ToListAsync();
    }

    public async Task<IEnumerable<StockProduct>> GetByStockIdAsync(int stockId)
    {
        return await _dbSet
            .Where(sp => sp.StockId == stockId)
            .Include(sp => sp.Product)
            .ToListAsync();
    }

    public async Task AddAsync(StockProduct entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void Update(StockProduct entity)
    {
        _dbSet.Update(entity);
    }

    public void Remove(StockProduct entity)
    {
        _dbSet.Remove(entity);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<bool> HasAvailableAsync(int stockId, int productId, int requestedQty)
    {
        var sp = await GetAsync(stockId, productId);
        if (sp == null) return false;
        return sp.Qty >= requestedQty + sp.Reserved;
    }
}