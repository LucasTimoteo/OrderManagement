using OrderManagement.Application.DTOs;
using OrderManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.Interfaces.Services;

public interface IPriceService
{
    (decimal unitPriceFinal, decimal unitDiscount, int chargedQty) Calculate(ProductWithPromotionsDto product, int qty);
}
