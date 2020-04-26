using OrderManager.DomainModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.DomainModel
{
    public class Employee
    {
        public Guid EmployeeID { get; set; }
        public string EmployeeNumber { get; set; } //jest loginem do aplikacji
        public string Password { get; set; }
        public Person Person { get; set; }

        public void AddNewEmployee(string employeeNumber, string password)
        {
            Person.PersonID = Guid.NewGuid();
            EmployeeNumber = employeeNumber;
            Password = password;
        }

        public Employee(Guid personID, string firstName, string lastName, string emailAdress, string phoneNumber, UserRole userRole) {}
        public Employee()
        {
            
        }
    }
}
