using OrderManagement.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.Interfaces.Services;

public interface IOrderService
{
    Task<OrderViewDto> CreateDraftAsync(OrderCreateDto dto, CancellationToken ct);
    Task ConfirmAsync(string orderNumber, CancellationToken ct);
    Task CancelAsync(string orderNumber, CancellationToken ct);
    Task<OrderViewDto?> GetAsync(string orderNumber, CancellationToken ct);
}
