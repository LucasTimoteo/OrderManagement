using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Domain.Entities
{
    public class ProductPromotion
    {
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public int PromotionId { get; set; }
        public Promotion Promotion { get; set; } = null!;
    }
}
