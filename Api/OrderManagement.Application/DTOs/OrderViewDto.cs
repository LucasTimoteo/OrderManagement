using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.DTOs;

public class OrderViewDto
{
    public string Number { get; set; }
    public string Status { get; set; }
    public int ClientId { get; set; }
    public string ClientName { get; set; }
    public decimal GrossTotal { get; set; }
    public decimal Discount { get; set; }
    public decimal NetTotal { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<OrderItemViewDto> Items { get; set; }
}

