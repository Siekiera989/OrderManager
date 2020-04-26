using System;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using OrderManager.Infrastructure.Interfaces;
using System.Windows;
using OrderManager.Infrastructure.DTO;
using System.Collections.ObjectModel;
using OrderManager.DesktopClient.View;
using System.Collections.Generic;
using OrderManager.DomainModel.Enums;

namespace OrderManager.DesktopClient.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IOrderService _orderService;
        private readonly IEmployeeService _employeeService;
        private readonly ICompanyService _companyService;
        private readonly ICustomerService _customerService;
        private ObservableCollection<CompanyDto> _companiesCollection;
        private bool _isUserLogged;
        private object _loginWindow;
        private bool _isLoginWindowVisible;
        private EmployeeDto _employee;
        private ObservableCollection<CustomerDto> _allCustomers;
        private CustomerDto _selectedCustomer;
        private object _newCustomerWindow;
        private bool _isNewCustomerWindowOpen;

        public bool IsUserLogged { get => _isUserLogged; set => Set(ref _isUserLogged, value); }

        public object LoginWindow { get => _loginWindow; set => Set(ref _loginWindow, value); }
        public bool IsLoginWindowVisible { get => _isLoginWindowVisible; set => Set(ref _isLoginWindowVisible, value); }
        public object NewCustomerWindow { get => _newCustomerWindow; set => Set(ref _newCustomerWindow, value); }
        public bool IsNewCustomerWindowOpen { get => _isNewCustomerWindowOpen; set => Set(ref _isNewCustomerWindowOpen, value); }
        public EmployeeDto Employee { get => _employee; set => Set(ref _employee, value); }
        public CustomerDto SelectedCustomer { get=>_selectedCustomer; set=>Set(ref _selectedCustomer,value); }

        public ObservableCollection<CompanyDto> CompaniesCollection { get => _companiesCollection; set => Set(ref _companiesCollection, value); }
        public ObservableCollection<CustomerDto> AllCustomers { get => _allCustomers; set => Set(ref _allCustomers, value); }
        

        public RelayCommand Loading { get; private set; }
        public RelayCommand AddNewCustomerComm { get; }

        public MainViewModel(IOrderService orderService, IEmployeeService employeeService, ICompanyService companyService, ICustomerService customerService)
        {
            _orderService = orderService;
            _employeeService = employeeService;
            _companyService = companyService;
            _customerService = customerService;
            _companiesCollection = new ObservableCollection<CompanyDto>();
            _allCustomers = new ObservableCollection<CustomerDto>();

            Loading = new RelayCommand(ShowLoginWindow);
            AddNewCustomerComm = new RelayCommand(AddNewCustomer);
        }

        private void AddNewCustomer()
        {
            try
            {
                NewCustomerWindow = new NewCustomer
                {
                    DataContext = ViewModelLocator.NewCustomerViewModel
                };
                RaisePropertyChanged(nameof(NewCustomerWindow));
                IsNewCustomerWindowOpen = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public async Task TryLoginUser(string employeeNumber, string password)
        {
            try
            {
                IsUserLogged = await _employeeService.Login(employeeNumber, password);
                if (!IsUserLogged) return;

                await LoadInfos(employeeNumber);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public async Task TryRegisterUser(string employeeNumber, string password)
        {
            try
            {
                await _employeeService.Register(employeeNumber, password);

                await LoadInfos(employeeNumber);
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
        }

        public void ShowLoginWindow()
        {
            LoginWindow = new LoginWindow
            {
                DataContext = ViewModelLocator.LoginViewModel
            };
            RaisePropertyChanged(nameof(LoginWindow));
            IsLoginWindowVisible = true;
        }

        private async Task LoadInfos(string employeeNumber)
        {
            try
            {
                Employee = await _employeeService.GetAccountByEmployeeNumber(employeeNumber);
                IsLoginWindowVisible = false;

                foreach (var company in await _companyService.GetAllCompanies())
                    CompaniesCollection.Add(company);

                foreach (var customer in await _customerService.GetAllCustomers())
                    AllCustomers.Add(customer);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}