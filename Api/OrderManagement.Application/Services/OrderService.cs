using AutoMapper;
using OrderManagement.Application.Builders;
using OrderManagement.Application.DTOs;
using OrderManagement.Application.Interfaces.Repositories;
using OrderManagement.Application.Interfaces.Services;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Enums;

namespace OrderManagement.Application.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orders;
    private readonly IProductRepository _products;
    private readonly IStockProductRepository _stockProducts;
    private readonly IPriceService _price;
    private readonly IMapper _mapper;

    public OrderService(
        IOrderRepository orders,
        IProductRepository products,
        IStockProductRepository stockProducts,
        IPriceService price,
        IMapper mapper)
    {
        _orders = orders;
        _products = products;
        _stockProducts = stockProducts;
        _price = price;
        _mapper = mapper;
    }

    public async Task<OrderViewDto> CreateDraftAsync(OrderCreateDto dto, CancellationToken ct)
    {
        var number = $"P{DateTime.UtcNow:yyyyMMddHHmmssfff}";
        var order = new Order { Number = number, ClientId = dto.ClientId, Status = OrderStatus.Draft };

        var productIds = dto.Items.Select(i => i.ProductId).Distinct().ToList();
        var products = await _products.GetWithPromotionsAndStocksAsync(productIds);

        foreach (var it in dto.Items)
        {
            var prod = products.Single(p => p.Id == it.ProductId);
            var stockRef = prod.StockProducts.FirstOrDefault()
                ?? throw new InvalidOperationException($"Produto {prod.Name} não está em nenhum estoque.");

            // Valida disponibilidade considerando reservas
            if (!await _stockProducts.HasAvailableAsync(stockRef.StockId, prod.Id, it.Qty))
                throw new InvalidOperationException($"Estoque insuficiente para {prod.Name}");

            // Reserva
            stockRef.Reserved += it.Qty;
            _stockProducts.Update(stockRef);

            var productWithPromotionsDto = ProductPromotionBuilder.Build(prod);

            var (unitFinal, unitDiscount, chargedQty) = _price.Calculate(productWithPromotionsDto, it.Qty);
            order.OrderItems.Add(new OrderItem
            {
                ProductId = prod.Id,
                Qty = it.Qty,
                UnitPrice = prod.Price,
                Discount = Math.Round(unitDiscount * it.Qty, 2),
                Total = Math.Round(unitFinal * chargedQty, 2)
            });
        }

        order.GrossTotal = order.OrderItems.Sum(i => i.UnitPrice * i.Qty);
        order.Discount = order.OrderItems.Sum(i => i.Discount);
        order.NetTotal = order.OrderItems.Sum(i => i.Total);

        await _orders.AddAsync(order);
        await _stockProducts.SaveChangesAsync();
        await _orders.SaveChangesAsync();

        return _mapper.Map<OrderViewDto>(order);
    }

    public async Task ConfirmAsync(string orderNumber, CancellationToken ct)
    {
        var order = await _orders.GetFullByNumberAsync(orderNumber)
            ?? throw new KeyNotFoundException("Pedido não encontrado");

        if (order.Status != OrderStatus.Draft)
            throw new InvalidOperationException("Somente rascunhos podem ser confirmados.");

        foreach (var item in order.OrderItems)
        {
            var stockRef = item.Product.StockProducts.FirstOrDefault();

            if (stockRef == null)
            {
                var stock = await _stockProducts.GetByProductIdAsync(item.Product.Id) ??
                    throw new InvalidOperationException($"Produto {item.Product.Name} não está em estoque.");

                stockRef = stock.FirstOrDefault() ??
                    throw new InvalidOperationException($"Produto {item.Product.Name} não possui registros de estoque.");
            }

            if (stockRef.Reserved < item.Qty)
                throw new InvalidOperationException($"Reserva insuficiente para {item.Product.Name}");

            stockRef.Qty -= item.Qty;
            stockRef.Reserved -= item.Qty;

            _stockProducts.Update(stockRef);
        }


        order.Status = OrderStatus.Confirmed;
        _orders.Update(order);

        await _stockProducts.SaveChangesAsync();
        await _orders.SaveChangesAsync();
    }

    public async Task CancelAsync(string orderNumber, CancellationToken ct)
    {
        var order = await _orders.GetFullByNumberAsync(orderNumber)
            ?? throw new KeyNotFoundException("Pedido não encontrado");

        if (order.Status == OrderStatus.Invoiced)
            throw new InvalidOperationException("Pedido faturado não pode ser cancelado.");

        foreach (var item in order.OrderItems)
        {
            var stockRef = item.Product.StockProducts.FirstOrDefault();
            if (stockRef != null)
            {
                if (stockRef == null)
                {
                    var stock = await _stockProducts.GetByProductIdAsync(item.Product.Id) ??
                        throw new InvalidOperationException($"Produto {item.Product.Name} não está em estoque.");

                    stockRef = stock.FirstOrDefault() ??
                        throw new InvalidOperationException($"Produto {item.Product.Name} não possui registros de estoque.");
                }

                if (order.Status == OrderStatus.Draft)
                {
                    stockRef.Reserved -= item.Qty;
                }
                else if (order.Status == OrderStatus.Confirmed)
                {
                    stockRef.Qty += item.Qty;
                }
                _stockProducts.Update(stockRef);
            }
        }

        order.Status = OrderStatus.Canceled;
        _orders.Update(order);

        await _stockProducts.SaveChangesAsync();
        await _orders.SaveChangesAsync();
    }

    public async Task<OrderViewDto?> GetAsync(string orderNumber, CancellationToken ct)
    {
        var order = await _orders.GetFullByNumberAsync(orderNumber);
        return order is null ? null : _mapper.Map<OrderViewDto>(order);
    }
    
}


