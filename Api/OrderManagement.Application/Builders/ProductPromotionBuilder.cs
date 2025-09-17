using OrderManagement.Application.DTOs;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Application.Builders;

public static class ProductPromotionBuilder
{
    public static ProductWithPromotionsDto Build(Product product)
    {
        var dto = new ProductWithPromotionsDto
        {
            Id = product.Id,
            Sku = product.Sku,
            Name = product.Name,
            Price = product.Price,
            IsActive = product.IsActive,
            Promotions = product.ProductPromotions
                .Where(pp => pp.Promotion != null && pp.Promotion.IsActive)
                .Select(pp => new PromotionDto
                {
                    Id = pp.Promotion.Id,
                    Name = pp.Promotion.Name,
                    PromotionType = pp.Promotion.PromotionType,
                    Percent = pp.Promotion.Percent,
                    FixedAmount = pp.Promotion.FixedAmount,
                    BuyX = pp.Promotion.BuyX,
                    PayY = pp.Promotion.PayY,
                    IsActive = pp.Promotion.IsActive
                }).ToList()
        };

        return dto;
    }
}

