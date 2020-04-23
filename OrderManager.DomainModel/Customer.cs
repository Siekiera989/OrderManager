using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManager.DomainModel.Enums;

namespace OrderManager.DomainModel
{
    public class Customer:Person
    {
        public Company Company { get; private set; }
        public int CompanyID { get; set; }

        public Company SetCompany(Company newCompany) => Company = newCompany;

        public Customer(){}
        public Customer(Guid personID, string firstName, string lastName, string emailAdress, string phoneNumber, UserRole userRole) : base(personID, firstName, lastName, emailAdress, phoneNumber, userRole){}
    }
}
