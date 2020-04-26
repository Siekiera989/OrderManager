using System;
using System.Collections.Generic;
using System.Linq;
using OrderManager.DomainModel.Enums;

namespace OrderManager.DomainModel
{
    public class Order
    {
        public int ID { get; set; }
        public int Number { get; set; }
        public int Month => IssueDate.Month;
        public int Year => IssueDate.Year;
        public string OrderNumber => $"PO {Number}/{Month}/{Year}/{OrderType}";
        public DateTime IssueDate { get; set; }
        public DateTime ConfirmationDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime EndDate { get; set; }
        public OrderType OrderType { get; set; }
        public Status OrderStatus { get; set; }
        public Priority OrderPriority { get; set; }
        public Customer Customer { get; set; } = new Customer();
        public Employee Employee { get; set; } = new Employee();
        public List<OrderItem> Items { get; set; }
        public decimal TotalValue => Items.Sum(item => (item.Amount * item.Item.UnitPrice));

        public override string ToString() => $"PO {Number}/{Month}/{Year}/{OrderType}";

        public Order()
        {
            Items = new List<OrderItem>();
        }
    }
}
