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
        Task<CustomerDto> GetAsyncById(int personId);
        Task CreateNewAsync(CustomerDto newCustomer);
        Task EditCustomer(CustomerDto customer);
        Task DeleteCustomer(int personId);
    }
}
