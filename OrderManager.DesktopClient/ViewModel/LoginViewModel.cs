using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using OrderManager.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OrderManager.DesktopClient.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        public RelayCommand LoginComm { get; }
        public RelayCommand RegisterComm { get; }

        private string _employeeNumber;
        private string _password;

        public string EmployeeNumber { get => _employeeNumber; set => Set(ref _employeeNumber, value); }
        public string Password { get => _password; set => Set(ref _password, value); }

        public LoginViewModel()
        {
           LoginComm = new RelayCommand(async () => await LoginUser());
           RegisterComm = new RelayCommand(async () => await RegisterUser());
        }

        private async Task RegisterUser()
        {
            try
            {
                var test = Guid.NewGuid();
                await ViewModelLocator.Main.TryRegisterUser(EmployeeNumber, Password);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private async Task LoginUser()
        {
            try
            {
                await ViewModelLocator.Main.TryLoginUser(EmployeeNumber, Password);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
