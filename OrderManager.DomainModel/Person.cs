using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using OrderManager.DomainModel.Enums;

namespace OrderManager.DomainModel
{
    public class Person
    {
        public int PersonID { get; set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string FullName => $"{LastName},{FirstName}";
        public string EmailAdress { get;  private set; }
        public string PhoneNumber { get; private set; }
        public UserRole UserRole { get;  private set; }

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


        public Person(string firstName, string lastName, string emailAdress, string phoneNumber, UserRole userRole)
        {
            SetPersonName(firstName, lastName);

            SetPersonData(emailAdress, phoneNumber);

            SetUserRole(userRole);
        }


        public Person()
        {
        }
    }
}
