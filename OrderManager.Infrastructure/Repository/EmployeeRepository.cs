using System;
using System.Linq;
using System.Threading.Tasks;
using OrderManager.DomainModel;
using OrderManager.DomainModel.Repositories;
using OrderManager.Infrastructure.Config;

namespace OrderManager.Infrastructure.Repository
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EmployeeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Employee> GetAsync(string employeeNumber) 
            => await Task.FromResult(_dbContext.Employees.SingleOrDefault(x => x.EmployeeNumber == employeeNumber));

        public async Task<Employee> GetByIdAsync(Guid personID) 
            => await Task.FromResult(_dbContext.Employees.SingleOrDefault(x => x.Person.PersonID==personID));

        public async Task AddAsync(Employee employee)
        {
            await _dbContext.Employees.AddAsync(employee);
            await Task.CompletedTask;
        }

        public async Task EditUser(Employee employee)
        {
             _dbContext.Employees.Update(employee);
             await Task.CompletedTask;
        }
    }
}
