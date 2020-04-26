using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManager.DomainModel;

namespace OrderManager.Infrastructure.DTO
{
    public class OrderItemDto
    {
        public int OrderItemID { get; set; }
        public decimal Amount { get; set; }
        public Item Item { get; set; }
    }
}
