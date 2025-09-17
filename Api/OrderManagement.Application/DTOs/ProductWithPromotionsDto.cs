namespace OrderManagement.Application.DTOs;

public class ProductWithPromotionsDto
{
    public int Id { get; set; }
    public string Sku { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public bool IsActive { get; set; }
    public List<PromotionDto> Promotions { get; set; } = new();
}
