using System;
using System.Threading.Tasks;

namespace OrderManager.DomainModel.Repositories
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetAsync(string employeeNumber);
        Task<Employee> GetByIdAsync(Guid personID);
        Task AddAsync(Employee employee);
        Task EditUser(Employee employee);
    }
}
