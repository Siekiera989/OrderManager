using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManager.DomainModel.Enums;
using OrderManager.Infrastructure.DTO;

namespace OrderManager.Infrastructure.Interfaces
{
    public interface IEmployeeService
    {
        Task<EmployeeDto> GetAccountById(int userId);
        Task<EmployeeDto> GetAccountByEmployeeNumber(string employeeNumber);
        Task<bool> Login(string employeeNumber, string password);
        Task Register(string employeeNumber, string password);
        Task EditUser(int personID, string firstName, string lastName, 
            string emailAdress, string phoneNumber, UserRole userRole);
    }
}
