using OrderManagement.Domain.Entities;

namespace OrderManagement.Application.Interfaces.Repositories;

public interface IOrderRepository : IRepository<Order> 
{
    Task<Order?> GetByNumberAsync(string number);
    Task<Order?> GetFullByNumberAsync(string number);
}
