using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using OrderManager.DomainModel;
using OrderManager.DomainModel.Repositories;
using OrderManager.Infrastructure.Config;
using OrderManager.Infrastructure.DTO;
using OrderManager.Infrastructure.Interfaces;

namespace OrderManager.Infrastructure.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
            _mapper = MapperConfig.Initialize();
        }
        public async Task<IEnumerable<CustomerDto>> GetAllCustomers()
        {
            var customers = await _customerRepository.GetAllCustomers();
            return _mapper.Map<IEnumerable<CustomerDto>>(customers);
        }

        public async Task<CustomerDto> GetAsyncById(Guid personId)
        {
            var customer = await _customerRepository.GetAsyncById(personId);
            return _mapper.Map<CustomerDto>(customer);
        }

        public async Task CreateNewAsync(Customer newCustomer)
        {
            var customer = await _customerRepository.GetAsyncById(newCustomer.PersonID);
            if (customer != null) throw new Exception("Customer already exists");

            customer = new Customer(Guid.NewGuid(), newCustomer.FirstName, newCustomer.LastName,
                newCustomer.EmailAdress, newCustomer.PhoneNumber, newCustomer.UserRole);
            await _customerRepository.CreateNewAsync(customer);

        }

        public async Task EditCustomer(Customer customer)
        {
            var cust = await _customerRepository.GetAsyncById(customer.PersonID);

            if (cust.FirstName != customer.FirstName || cust.LastName != customer.LastName)
                cust.SetPersonName(customer.FirstName, customer.LastName);

            if (cust.EmailAdress!=customer.EmailAdress||cust.PhoneNumber!=customer.PhoneNumber)
                cust.SetPersonData(customer.EmailAdress,customer.PhoneNumber);

            if (cust.UserRole != customer.UserRole)
               cust.SetUserRole(customer.UserRole);

            if (!cust.Company.Equals(customer.Company))
                cust.SetCompany(customer.Company);

            await _customerRepository.EditCustomer(cust);
        }

        public async Task DeleteCustomer(Guid personId) => await _customerRepository.DeleteCustomer(personId);
    }
}
