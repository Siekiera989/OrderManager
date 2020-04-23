using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.DomainModel
{
    //Dlaczego opakowanie dziedziczy po przedmiocie?
    //Dlatego, że przedmiot jest najniższą encją i takie dziedziczenie umożliwia rozszerzenie dalszej fonkcjonalności aplikacji
    //Np wsparcie procesu zakupowego, ponieważ opakowania trzeba kupić oraz wsparcie procesu produkcjyjnego ze względu na tworzenie BOM (Bill Of Material).
    //Ponadto opakowanie może być kaucjonowane i brak zwrotu może być podstawą wystawienia faktury
    public class Package:Item
    {
        public int PackageID { get; set; }
        public string Type { get; set; }
        public OrderItem OrderItem { get; set; }
        public int OrderItemRef { get; set; }
        public Package(string productCode, string name, string unit, decimal unitPrice, decimal amount) : base(productCode, name, unit, unitPrice, amount)
        {
            MinimumLT = 0;
        }
    }
}
