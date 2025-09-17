using OrderManagement.Domain.Enums;

namespace OrderManagement.Application.DTOs;

public class PromotionDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public PromotionType PromotionType { get; set; }
    public decimal? Percent { get; set; }
    public decimal? FixedAmount { get; set; }
    public int? BuyX { get; set; }
    public int? PayY { get; set; }
    public bool IsActive { get; set; }
}

