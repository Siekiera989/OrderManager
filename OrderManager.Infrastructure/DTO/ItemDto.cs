using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Infrastructure.DTO
{
    public class ItemDto
    {
        public int ItemID { get; set; }
        public string ProductCode { get; set; }
        public string Name { get; set; }
        public decimal UnitQuantity { get; set; }
        public string Unit { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal MinimumLT { get; set; }
        public decimal MOQ { get; set; }
    }
}
