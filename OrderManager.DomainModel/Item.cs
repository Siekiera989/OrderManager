using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.DomainModel
{
    public abstract class Item
    {
        public string ProductCode { get; protected set; }
        public string Name { get; protected set; }
        public decimal UnitQuantity { get; protected set; }
        public string Unit { get; protected set; }
        public decimal UnitPrice { get; protected set; }
        public decimal Amount { get; protected set; }
        public int ItemFK { get; set; }

        //Minimum Lead Time - najkrótszy czas kiedy można dostarczyć dany towar.
        //Może również służyć do tego, aby określić całkowity czas do dostarczenia gotowego produktu,
        //jeśli stworzenie gotowego produktu wymaga kilku etapów
        public decimal MinimumLT { get; protected set; }

        protected Item(string productCode, string name, string unit, decimal unitPrice, decimal amount)
        {
            CreateNewItem( productCode, name,  unit, unitPrice, amount);
        }

        public void CreateNewItem( string productCode, string name, string unit, decimal unitPrice,
            decimal amount)
        {
            ProductCode = productCode;
            Name = name;
            Unit = unit;
            UnitPrice = unitPrice;
            Amount = amount;
        }

        public void SetName(string productCode, string productName)
        {
            ProductCode = productCode;
            Name = productName;
        }

        public void SetUnitQuantity(decimal unitQuantity) => UnitQuantity = unitQuantity;
        public void SetUnit(string unit) => Unit = unit;
        public void SetUnitPrice(decimal unitPrice) => UnitPrice = unitPrice;
        public void SetAmount(decimal amount) => Amount = amount;
        public void SetMinimumLT(decimal minimumLT) => MinimumLT = minimumLT;
    }
}
