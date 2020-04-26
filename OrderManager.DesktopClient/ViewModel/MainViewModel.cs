using System;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using OrderManager.DomainModel.Repositories;
using OrderManager.Infrastructure.Interfaces;
using OrderManager.Infrastructure.Service;
using OrderManager.Infrastructure.Services;
using System.Windows;
using OrderManager.Infrastructure.DTO;
using System.Collections.ObjectModel;
using OrderManager.DomainModel;

namespace OrderManager.DesktopClient.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IOrderService _orderService;
        private readonly IEmployeeService _employeeService;
        private readonly ICompanyService _companyService;
        private ObservableCollection<CompanyDto> _companiesCollection;

        public ObservableCollection<CompanyDto> CompaniesCollection { get => _companiesCollection; set => Set(ref _companiesCollection, value); }

        public RelayCommand Loading { get; private set; }

        public MainViewModel(IOrderService orderService, IEmployeeService employeeService, ICompanyService companyService)
        {
            _orderService = orderService;
            _employeeService = employeeService;
            _companyService = companyService;

            _companiesCollection = new ObservableCollection<CompanyDto>();

            Loading = new RelayCommand(async () => await OnLoading());
        }

        private async Task OnLoading()
        {
            try
            {
                foreach (var company in await _companyService.GetAllCompanies())
                    CompaniesCollection.Add(company);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}