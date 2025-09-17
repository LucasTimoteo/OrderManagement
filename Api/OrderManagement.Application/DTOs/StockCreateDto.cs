using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.DTOs;

public class StockCreateDto
{
    public string Name { get; set; } = string.Empty;
    public string? Localization { get; set; }
}