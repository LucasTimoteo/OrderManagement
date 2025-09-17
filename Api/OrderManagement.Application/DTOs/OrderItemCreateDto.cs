using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.DTOs;

public class OrderItemCreateDto
{
    public int ProductId { get; set; }
    public int Qty { get; set; }
}

