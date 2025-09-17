using OrderManagement.Domain.Entities;

namespace OrderManagement.Application.Interfaces.Repositories;

public interface IProductPromotionRepository
{
    Task<IEnumerable<ProductPromotion>> GetAllAsync();
    Task<IEnumerable<ProductPromotion>> GetByProductIdAsync(int productId);
    Task<IEnumerable<ProductPromotion>> GetByPromotionIdAsync(int promotionId);
    Task AddAsync(ProductPromotion entity);
    Task RemoveAsync(ProductPromotion entity);
    Task SaveChangesAsync();
}
