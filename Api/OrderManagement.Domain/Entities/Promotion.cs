using OrderManagement.Domain.Enums;

namespace OrderManagement.Domain.Entities;

public class Promotion
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public PromotionType PromotionType { get; set; }
    public decimal? Percent { get; set; }
    public decimal? FixedAmount { get; set; }
    public int? BuyX { get; set; }
    public int? PayY { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public virtual ICollection<ProductPromotion> ProductPromotions { get; set; } = new List<ProductPromotion>();
}
