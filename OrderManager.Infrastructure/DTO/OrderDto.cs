using System;
using System.Collections.Generic;
using OrderManager.DomainModel;
using OrderManager.DomainModel.Enums;

namespace OrderManager.Infrastructure.DTO
{
    public class OrderDto
    {
        public int ID { get; set; }
        public int Number { get; set; }
        public int Month { get; set; }
        public int Year {get; set; }
        public string OrderNumber { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ConfirmationDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime EndDate { get; set; }
        public OrderType OrderType { get; set; }
        public Status OrderStatus { get; set; }
        public Priority OrderPriority { get; set; }
        public CustomerDto Customer { get; set; }
        public EmployeeDto Employee { get; set; }
        public List<OrderItemDto> Items { get; set; }

    }
}
