using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.DTOs;

public class OrderCreateDto
{
    public int ClientId { get; set; }
    public List<OrderItemCreateDto> Items { get; set; }
}

