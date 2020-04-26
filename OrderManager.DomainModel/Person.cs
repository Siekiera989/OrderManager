using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using OrderManager.DomainModel.Enums;

namespace OrderManager.DomainModel
{
    public class Person
    {
        public Guid PersonID { get; set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string FullName => $"{LastName},{FirstName}";
        public string EmailAdress { get; protected set; }
        public string PhoneNumber { get; protected set; }
        public UserRole UserRole { get; protected set; }

        public void SetPersonName(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public void SetPersonData(string emailAdress, string phoneNumber)
        {
            EmailAdress = emailAdress;
            PhoneNumber = phoneNumber;
        }

        public void SetUserRole(UserRole newRole)
        {
            UserRole = newRole;
        }


        protected Person(Guid ID, string firstName, string lastName, string emailAdress, string phoneNumber, UserRole userRole)
        {
            PersonID = ID;

            SetPersonName(firstName, lastName);

            SetPersonData(emailAdress, phoneNumber);

            SetUserRole(userRole);
        }


        protected Person()
        {
        }
    }
}
