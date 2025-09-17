using OrderManagement.Domain.Enums;

namespace OrderManagement.Domain.Entities;

public class Order
{
    public int Id { get; set; }
    public string Number { get; set; } = null!;
    public OrderStatus Status { get; set; } = OrderStatus.Draft;
    public decimal GrossTotal { get; set; }
    public decimal Discount { get; set; }
    public decimal NetTotal { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public int ClientId { get; set; }
    public virtual Client Client { get; set; } = null!;
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}