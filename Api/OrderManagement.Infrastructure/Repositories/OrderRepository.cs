using Microsoft.EntityFrameworkCore;
using OrderManagement.Application.Interfaces.Repositories;
using OrderManagement.Domain.Entities;
using OrderManagement.Infrastructure.Data;

namespace OrderManagement.Infrastructure.Repositories;

public class OrderRepository : Repository<Order>, IOrderRepository
{
    public OrderRepository(AppDbContext context) : base(context) { }

    public async Task<Order?> GetByNumberAsync(string number) =>
        await _dbSet.FirstOrDefaultAsync(o => o.Number == number);

    public async Task<Order?> GetFullByNumberAsync(string number) =>
        await _dbSet
            .Include(o => o.Client)
            .Include(o => o.OrderItems).ThenInclude(oi => oi.Product)
            .FirstOrDefaultAsync(o => o.Number == number);
}