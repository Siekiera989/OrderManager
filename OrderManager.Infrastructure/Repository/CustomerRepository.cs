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
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomerRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
            => await _dbContext.Customers
                        .Include(x=>x.Person)
                        .Include(x => x.Company)
                        .ToListAsync();

        public async Task<Customer> GetAsyncById(int personId)
            => await Task.FromResult(_dbContext.Customers.SingleOrDefault(x => x.Person.PersonID == personId));

        public async Task CreateNewAsync(Customer newCustomer)
        {
            await _dbContext.Customers.AddAsync(newCustomer);
            await _dbContext.SaveChangesAsync();
        }


        public async Task EditCustomer(Customer customer)
        {
            _dbContext.Customers.Update(customer);
            await _dbContext.SaveChangesAsync();

            await Task.CompletedTask;
        }

        public async Task DeleteCustomer(int personId)
        {
            _dbContext.Customers.Remove(await GetAsyncById(personId));
            await _dbContext.SaveChangesAsync();

            await Task.CompletedTask;
        }
    }
}
