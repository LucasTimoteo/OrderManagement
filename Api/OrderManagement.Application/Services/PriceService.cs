using OrderManagement.Application.DTOs;
using OrderManagement.Application.Interfaces.Services;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.Services;

public class PriceService : IPriceService
{
    public (decimal, decimal, int) Calculate(ProductWithPromotionsDto product, int qty)
    {
        decimal discountUnit = 0m;
        int chargedQty = qty;

        if (product.Promotions != null)
        {
            foreach (var promo in product.Promotions.Where(p => p.IsActive))
            {
                switch (promo.PromotionType)
                {
                    case PromotionType.Percent when promo.Percent.HasValue:
                        discountUnit += Math.Round(product.Price * (promo.Percent.Value / 100m), 2);
                        break;

                    case PromotionType.FixedAmount when promo.FixedAmount.HasValue:
                        discountUnit += Math.Min(promo.FixedAmount.Value, product.Price);
                        break;

                    case PromotionType.BuyXPayY when promo.BuyX.HasValue && promo.PayY.HasValue:
                        if (qty >= promo.BuyX.Value)
                        {
                            var groups = qty / promo.BuyX.Value;
                            var remainder = qty % promo.BuyX.Value;
                            chargedQty = groups * promo.PayY.Value + remainder;
                            var freeItems = qty - chargedQty;
                            var totalDiscount = freeItems * product.Price;
                            discountUnit += Math.Round(totalDiscount / qty, 2);
                        }
                        break;
                }
            }
        }

        var finalUnitPrice = Math.Max(0m, product.Price - discountUnit);
        return (finalUnitPrice, discountUnit, chargedQty);
    }
}
