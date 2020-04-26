using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderManager.DomainModel.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task<Customer> GetAsyncById(int personId);
        Task CreateNewAsync(Customer newCustomer);
        Task EditCustomer(Customer customer);
        Task DeleteCustomer(int personId);
    }
}
