using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.DomainModel
{
    public class OrderItem
    {
        public int OrderItemID{get;set;}
        public decimal Amount { get; private set; }
        public bool IsMOQ => Amount >= Item.MOQ;
        public Item Item { get; set; }

        public OrderItem()
        {
        }
        public OrderItem(string productCode, string name, string unit, decimal unitPrice, decimal amount)
        {
            Item.CreateNewItem(productCode, name, unit, unitPrice);
            Amount = amount;
        }
        public void SetAmount(decimal amount) => Amount = amount;
    }
}
