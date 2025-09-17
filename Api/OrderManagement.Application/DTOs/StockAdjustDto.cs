namespace OrderManagement.Application.DTOs;

public class StockAdjustDto
{
    public int StockId { get; set; }
    public int ProductId { get; set; }
    public int QtyDelta { get; set; }
}
