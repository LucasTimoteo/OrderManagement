namespace OrderManagement.Domain.Entities;

public class StockProduct
{
    public int StockId { get; set; }
    public Stock Stock { get; set; } = null!;
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;
    public int Qty { get; set; }
    public int Reserved { get; set; }
}

