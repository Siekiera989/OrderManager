using GalaSoft.MvvmLight;
using OrderManager.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.DesktopClient.ViewModel
{
    public class NewCustomerViewModel:ViewModelBase
    {
        private readonly ICustomerService _customerService;



        public NewCustomerViewModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }
    }
}
