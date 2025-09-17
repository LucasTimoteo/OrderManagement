using Microsoft.EntityFrameworkCore;
using OrderManagement.Application.Interfaces.Repositories;
using OrderManagement.Domain.Entities;
using OrderManagement.Infrastructure.Data;


namespace OrderManagement.Infrastructure.Repositories;

public class ProductPromotionRepository : IProductPromotionRepository
{
    private readonly AppDbContext _context;
    private readonly DbSet<ProductPromotion> _dbSet;

    public ProductPromotionRepository(AppDbContext context)
    {
        _context = context;
        _dbSet = context.Set<ProductPromotion>();
    }

    public async Task<IEnumerable<ProductPromotion>> GetAllAsync() =>
        await _dbSet.ToListAsync();

    public async Task<IEnumerable<ProductPromotion>> GetByProductIdAsync(int productId) =>
        await _dbSet.Where(pp => pp.ProductId == productId).ToListAsync();

    public async Task<IEnumerable<ProductPromotion>> GetByPromotionIdAsync(int promotionId) =>
        await _dbSet.Where(pp => pp.PromotionId == promotionId).ToListAsync();

    public async Task AddAsync(ProductPromotion entity) =>
        await _dbSet.AddAsync(entity);

    public async Task RemoveAsync(ProductPromotion entity)
    {
        _dbSet.Remove(entity);
        await Task.CompletedTask;
    }

    public async Task SaveChangesAsync() =>
        await _context.SaveChangesAsync();
}
