using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.DomainModel
{
    public class Order
    {
        public Guid ID { get; set; }
        public string OrderNumber { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DueDate { get; set; }
        public decimal TotalValue { get; set; }
        public OrderType OrderType { get; set; }
        public Status OrderStatus { get; set; }
        public Priority OrderPriority { get; set; }
        public Customer Issuer { get; set; }
        public ObservableCollection<Item> Items { get; set; }
    }
}
