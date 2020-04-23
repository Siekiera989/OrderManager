using System;
using System.Threading.Tasks;
using AutoMapper;
using OrderManager.DomainModel;
using OrderManager.DomainModel.Enums;
using OrderManager.DomainModel.Repositories;
using OrderManager.Infrastructure.Config;
using OrderManager.Infrastructure.DTO;
using OrderManager.Infrastructure.Interfaces;

namespace OrderManager.Infrastructure.Service
{
    public class EmployeeService:IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _mapper = MapperConfig.Initialize();
        }
        public async Task<bool> Login(string employeeNumber, string password)
        {
            //W prawdziwie działającej aplikacji powinienem zaszyfrować hasło i wtedy porównać,
            //ponieważ w bazie nie trzyma się jawnie haseł
            var user = await _employeeRepository.GetAsync(employeeNumber);

            if (user==null) throw new Exception("Invalid credentials");
            if (user.Password!=password) throw new Exception("Invalid credentials");

            return true;
        }

        public async Task Register(string employeeNumber, string password)
        {
            var user = await _employeeRepository.GetAsync(employeeNumber);
            if (user!=null) throw new Exception($"User with login: '{employeeNumber}' already exists");
            
            user = new Employee();
            user.AddNewEmployee(employeeNumber,password);
            await _employeeRepository.AddAsync(user);
        }

        public async Task<EmployeeDto> GetAccount(Guid userId)
        {
            var user = await _employeeRepository.GetByIdAsync(userId);
            return _mapper.Map<EmployeeDto>(user);
        }

        public async Task EditUser(Guid personID, string firstName="", string lastName="", string emailAdress="", string phoneNumber="",
            UserRole userRole=UserRole.Employee)
        {
            var user = await _employeeRepository.GetByIdAsync(personID);

            if ((string.IsNullOrEmpty(user.FirstName) || string.IsNullOrEmpty(user.LastName))||
                (user.FirstName!=firstName||user.LastName!=lastName))
                user.SetPersonName(firstName,lastName);
            
            if ((string.IsNullOrEmpty(user.EmailAdress) || string.IsNullOrEmpty(user.PhoneNumber))||
                (user.EmailAdress!=emailAdress||user.PhoneNumber!=phoneNumber))
                user.SetPersonData(emailAdress,phoneNumber);

            if (user.UserRole!=userRole)
                user.SetUserRole(userRole);


            await _employeeRepository.EditUser(user);

        }
    }
}
