using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderManager.DomainModel;
using OrderManager.DomainModel.Repositories;
using OrderManager.Infrastructure.Config;

namespace OrderManager.Infrastructure.Repository
{
    public class CustomerRepository:ICustomerRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomerRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
            => await _dbContext.Customers.ToListAsync();

        public async Task<Customer> GetAsyncById(Guid personId) 
            => await Task.FromResult(_dbContext.Customers.SingleOrDefault(x => x.Person.PersonID == personId));

        public async Task CreateNewAsync(Customer newCustomer) 
            => await _dbContext.Customers.AddAsync(newCustomer);

        public async Task EditCustomer(Customer customer)
        {
            _dbContext.Customers.Update(customer);
            await Task.CompletedTask;
        }

        public async Task DeleteCustomer(Guid personId)
        {
            _dbContext.Customers.Remove(await GetAsyncById(personId));
            await Task.CompletedTask;
        }
    }
}
