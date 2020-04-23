using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManager.DomainModel;
using OrderManager.DomainModel.Enums;

namespace OrderManager.Infrastructure.DTO
{
    public class CustomerDto
    {
        public Guid PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get;  set; }
        public string FullName { get; set; }
        public string EmailAdress { get; set; }
        public string PhoneNumber { get; set; }
        public UserRole UserRole { get; set; }
        public List<Order> OwnedOrders { get; set; }
        public Company Company { get; set; }
        public int CompanyID { get; set; }
    }
}
