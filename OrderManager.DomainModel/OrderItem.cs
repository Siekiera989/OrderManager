using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.DomainModel
{
    public class OrderItem : Item
    {
        public int ItemID { get; set; }
        public decimal MOQ { get; set; } //Minimum Order Quantity
        public decimal PackageCapacity { get; set; }
        public Package Package { get; set; }
        public int PackagesCount => Convert.ToInt32(Math.Ceiling(Amount / PackageCapacity));
        public bool IsMOQ => Amount >= MOQ;
        public decimal TotalItemValue => PackagesCount * Package.UnitPrice;
        public Order RelatedOrder { get; set; }

        public OrderItem(string productCode, string name, string unit, decimal unitPrice, decimal amount) : base(productCode, name, unit, unitPrice, amount)
        {
            MinimumLT += Package.MinimumLT;
        }
    }
}
