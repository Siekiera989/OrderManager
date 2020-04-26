using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManager.DomainModel;
using OrderManager.DomainModel.Enums;

namespace OrderManager.Infrastructure.DTO
{
    public class EmployeeDto
    {
        public Guid EmployeeID { get; set; }
        public string EmployeeNumber { get; set; } 
        public string Password { get; set; }
        public Person Person { get; set; }
    }
}
