using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using OrderManager.DomainModel.Repositories;
using OrderManager.Infrastructure.Config;
using OrderManager.Infrastructure.Interfaces;
using OrderManager.Infrastructure.Repository;
using OrderManager.Infrastructure.Service;
using OrderManager.Infrastructure.Services;


namespace OrderManager.DesktopClient.ViewModel
{
   public class ViewModelLocator
    {
       
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<IOrderRepository,OrderRepository>();
            SimpleIoc.Default.Register<IOrderService,OrderService>();
            SimpleIoc.Default.Register<ICompanyRepository, CompanyRepository>();
            SimpleIoc.Default.Register<ICompanyService, CompanyService>();
            SimpleIoc.Default.Register<ICustomerRepository, CustomerRepository>();
            SimpleIoc.Default.Register<ICustomerService, CustomerService>();
            SimpleIoc.Default.Register<IEmployeeRepository, EmployeeRepository>();
            SimpleIoc.Default.Register<IEmployeeService, EmployeeService>();
            SimpleIoc.Default.Register<ApplicationDbContext>();
            SimpleIoc.Default.Register<MapperConfig>();
            SimpleIoc.Default.Register<MainViewModel>();
        }

        public static MainViewModel Main 
            => ServiceLocator.Current.GetInstance<MainViewModel>();

        public static void Cleanup()
        {
            SimpleIoc.Default.Reset();
        }
    }
}