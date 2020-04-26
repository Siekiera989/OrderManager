using OrderManager.DomainModel.Enums;
using System;

namespace OrderManager.DomainModel
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public Company Company { get; private set; }
        public Person Person { get; set; }
        public Company SetCompany(Company newCompany) => Company = newCompany;


        public Customer() { }
        public Customer(string firstName, string lastName, string emailAdress, string phoneNumber, UserRole userRole)
        {
            Person = new Person(firstName, lastName, emailAdress, phoneNumber, userRole);
        }
    }
}