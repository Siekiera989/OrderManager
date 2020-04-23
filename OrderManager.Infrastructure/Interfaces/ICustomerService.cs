using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManager.DomainModel;
using OrderManager.Infrastructure.DTO;

namespace OrderManager.Infrastructure.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDto>> GetAllCustomers();
        Task<CustomerDto> GetAsyncById(Guid personId);
        Task CreateNewAsync(Customer newCustomer);
        Task EditCustomer(Customer customer);
        Task DeleteCustomer(Guid personId);
    }
}
