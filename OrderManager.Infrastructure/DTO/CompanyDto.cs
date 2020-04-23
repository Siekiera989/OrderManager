using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManager.DomainModel;

namespace OrderManager.Infrastructure.DTO
{
    public class CompanyDto
    {
        public int ID { get; set; }
        public string Name { get; private set; }
        public string Country { get; private set; }
        public string City { get; private set; }
        public string Street { get; private set; }
        public string ZipCode { get; private set; }
        public List<Customer> ExternalCompanyEmployees { get; set; } = new List<Customer>();
    }
}
