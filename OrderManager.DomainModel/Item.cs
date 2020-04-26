using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.DomainModel
{
    public class Item
    {
        public int ItemID { get; set; }
        public string ProductCode { get; private set; }
        public string Name { get; private set; }
        public decimal UnitQuantity { get; private set; }
        public string Unit { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal MinimumLT { get; private set; }
        public decimal MOQ { get; private set; } //Minimum Order Quantity

        public void CreateNewItem(string productCode, string name, string unit, decimal unitPrice)
        {
            ProductCode = productCode;
            Name = name;
            Unit = unit;
            UnitPrice = unitPrice;
        }

        public void SetName(string productCode, string productName)
        {
            ProductCode = productCode;
            Name = productName;
        }

        public void SetUnitQuantity(decimal unitQuantity) => UnitQuantity = unitQuantity;
        public void SetUnit(string unit) => Unit = unit;
        public void SetUnitPrice(decimal unitPrice) => UnitPrice = unitPrice;
        public void SetMinimumLT(decimal minimumLT) => MinimumLT = minimumLT;
    }
}
