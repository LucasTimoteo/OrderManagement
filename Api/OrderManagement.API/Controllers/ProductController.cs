using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.DTOs;
using OrderManagement.Application.Interfaces.Repositories;
using OrderManagement.Domain.Entities;

namespace OrderManagement.API.Controllers;

[ApiController]
[Route("api/product")]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _products;
    private readonly IMapper _mapper;

    public ProductController(IProductRepository products, IMapper mapper)
    {
        _products = products;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<ProductViewDto>> Get()
    {
        var list = await _products.GetAllAsync();
        return list.Select(_mapper.Map<ProductViewDto>).Where(x => x.IsActive);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ProductCreateDto dto)
    {
        var entity = new Product
        {
            Sku = dto.Sku,
            Name = dto.Name,
            Price = dto.Price,
            IsActive = dto.IsActive
        };
        await _products.AddAsync(entity);
        await _products.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = entity.Id }, _mapper.Map<ProductViewDto>(entity));
    }
}

