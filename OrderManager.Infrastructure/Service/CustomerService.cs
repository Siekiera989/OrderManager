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

        public CustomerService(ICustomerRepository customerRepository,MapperConfig mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper.Initialize();
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
            var customer = await _customerRepository.GetAsyncById(newCustomer.Person.PersonID);
            if (customer != null) throw new Exception("Customer already exists");

            customer = new Customer(Guid.NewGuid(), newCustomer.Person.FirstName, newCustomer.Person.LastName,
                newCustomer.Person.EmailAdress, newCustomer.Person.PhoneNumber, newCustomer.Person.UserRole);
            await _customerRepository.CreateNewAsync(customer);

        }

        public async Task EditCustomer(Customer customer)
        {
            var cust = await _customerRepository.GetAsyncById(customer.Person.PersonID);

            if (cust.Person.FirstName != customer.Person.FirstName || cust.Person.LastName != customer.Person.LastName)
                cust.Person.SetPersonName(customer.Person.FirstName, customer.Person.LastName);

            if (cust.Person.EmailAdress !=customer.Person.EmailAdress ||cust.Person.PhoneNumber !=customer.Person.PhoneNumber)
                cust.Person.SetPersonData(customer.Person.EmailAdress,customer.Person.PhoneNumber);

            if (cust.Person.UserRole != customer.Person.UserRole)
               cust.Person.SetUserRole(customer.Person.UserRole);

            if (!cust.Company.Equals(customer.Company))
                cust.SetCompany(customer.Company);

            await _customerRepository.EditCustomer(cust);
        }

        public async Task DeleteCustomer(Guid personId) => await _customerRepository.DeleteCustomer(personId);
    }
}
