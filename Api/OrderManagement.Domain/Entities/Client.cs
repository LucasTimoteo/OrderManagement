
namespace OrderManagement.Domain.Entities;

public class Client
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}

