using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.DomainModel
{
    public class Employee : Person
    {
        public string EmployeeNumber { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
