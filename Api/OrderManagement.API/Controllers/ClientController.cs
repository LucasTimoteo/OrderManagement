using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.DTOs;
using OrderManagement.Application.Interfaces.Repositories;
using OrderManagement.Domain.Entities;

namespace OrderManagement.API.Controllers;

[ApiController]
[Route("api/client")]
public class ClientController : ControllerBase
{
    private readonly IClientRepository _clients;
    private readonly IMapper _mapper;

    public ClientController(IClientRepository clients, IMapper mapper)
    {
        _clients = clients;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<ClientViewDto>> Get()
    {
        var list = await _clients.GetAllAsync();
        return list.Select(_mapper.Map<ClientViewDto>);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ClientCreateDto dto)
    {
        var entity = new Client
        {
            Name = dto.Name,
            Email = dto.Email
        };
        await _clients.AddAsync(entity);
        await _clients.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = entity.Id }, _mapper.Map<ClientViewDto>(entity));
    }
}
