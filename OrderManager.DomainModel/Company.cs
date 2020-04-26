using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.DomainModel
{
    public class Company
    {
        public int ID { get; set; }
        public string Name { get; private set; }
        public string Country { get; private set; }
        public string City { get; private set; }
        public string Street { get; private set; }
        public string ZipCode { get; private set; }

        public Company()
        {
            
        }
        public Company(string name, string country, string city, string street, string zipCode)
        {
            Name = name;
            Country = country;
            City = city;
            Street = street;
            ZipCode = zipCode;
            
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new Exception("Name cannot be empty");
            Name = name;
        }

        public void SetAdress(string country, string city, string street, string zipCode)
        {
            if (string.IsNullOrWhiteSpace(country)||string.IsNullOrWhiteSpace(city)||string.IsNullOrWhiteSpace(street)||string.IsNullOrWhiteSpace(zipCode))
                throw new Exception("Neither of address field cannot be empty");
            Country = country;
            City = city;
            Street = street;
            ZipCode = zipCode;
        }
    }
}
