using OrderManager.DomainModel.Enums;
using System;

namespace OrderManager.DomainModel
{
    public class Customer
    {
        public Guid CustomerID { get; set; }
        public Company Company { get; set; }
        public Person Person { get; set; }
        public Company SetCompany(Company newCompany) => Company = newCompany;

        public Customer() { }
        public Customer(Guid personID, string firstName, string lastName, string emailAdress, string phoneNumber, UserRole userRole) { }
    }
}
