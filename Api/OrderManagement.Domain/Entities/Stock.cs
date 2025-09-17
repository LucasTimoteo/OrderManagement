
namespace OrderManagement.Domain.Entities;

public class Stock
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Localization { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public virtual ICollection<StockProduct> StockProducts { get; set; } = new List<StockProduct>();

}

