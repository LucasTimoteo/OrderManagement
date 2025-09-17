using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.DTOs;
using OrderManagement.Application.Interfaces.Services;

namespace OrderManagement.API.Controllers;

[ApiController]
[Route("api/order")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] OrderCreateDto dto, CancellationToken ct)
    {
        try
        {
            var result = await _orderService.CreateDraftAsync(dto, ct);
            return CreatedAtAction(nameof(GetByNumber), new { number = result.Number }, result);
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new { error = ex.Message });
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { error = ex.Message });
        }
    }

    [HttpGet("{number}")]
    public async Task<IActionResult> GetByNumber(string number, CancellationToken ct)
    {
        var result = await _orderService.GetAsync(number, ct);
        if (result is null) return NotFound(new { error = "Pedido não encontrado" });
        return Ok(result);
    }

    [HttpPost("{number}/confirm")]
    public async Task<IActionResult> Confirm(string number, CancellationToken ct)
    {
        try
        {
            await _orderService.ConfirmAsync(number, ct);
            return NoContent();
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new { error = ex.Message });
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { error = ex.Message });
        }
    }

    [HttpPost("{number}/cancel")]
    public async Task<IActionResult> Cancel(string number, CancellationToken ct)
    {
        try
        {
            await _orderService.CancelAsync(number, ct);
            return NoContent();
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new { error = ex.Message });
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { error = ex.Message });
        }
    }
}
