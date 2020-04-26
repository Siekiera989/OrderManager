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
        public int EmployeeID { get; set; }
        public string EmployeeNumber { get; set; } //jest loginem do aplikacji
        public string Password { get; set; }
        public Person Person { get; set; } = new Person();

        public void AddNewEmployee(string employeeNumber, string password)
        {
            EmployeeNumber = employeeNumber;
            Password = password;
        }

        public Employee(string firstName, string lastName, string emailAdress, string phoneNumber, UserRole userRole)
        {
            Person = new Person(firstName, lastName, emailAdress, phoneNumber, userRole);
        }
        public Employee()
        {

        }
    }
}
