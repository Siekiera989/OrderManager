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

        public EmployeeService(IEmployeeRepository employeeRepository, MapperConfig mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper.Initialize();
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

        public async Task<EmployeeDto> GetAccountById(int userId)
        {
            var user = await _employeeRepository.GetByIdAsync(userId);
            return _mapper.Map<EmployeeDto>(user);
        }

        public async Task<EmployeeDto> GetAccountByEmployeeNumber(string employeeNumber)
        {
            var user = await _employeeRepository.GetAsync(employeeNumber);
            if (user == null) throw new Exception("User doesn't exists");

            return _mapper.Map<EmployeeDto>(user);
        }

        public async Task EditUser(int personID, string firstName="", string lastName="", string emailAdress="", string phoneNumber="",
            UserRole userRole=UserRole.Employee)
        {
            var user = await _employeeRepository.GetByIdAsync(personID);

            if ((string.IsNullOrEmpty(user.Person.FirstName) || string.IsNullOrEmpty(user.Person.LastName))||
                (user.Person.FirstName!=firstName|| user.Person.LastName != lastName))
                user.Person.SetPersonName(firstName,lastName);
            
            if ((string.IsNullOrEmpty(user.Person.EmailAdress) || string.IsNullOrEmpty(user.Person.PhoneNumber))||
                (user.Person.EmailAdress!=emailAdress|| user.Person.PhoneNumber!=phoneNumber))
                user.Person.SetPersonData(emailAdress,phoneNumber);

            if (user.Person.UserRole!=userRole)
                user.Person.SetUserRole(userRole);


            await _employeeRepository.EditUser(user);

        }
    }
}
