using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.DomainModel
{
    public abstract class Person
    {
        public Guid PersonID { get; set; }
        public int PersonTableFK { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{LastName},{FirstName}";
        public string EmailAdress { get; set; }
        public string PhoneNumber { get; set; }
        public UserRole UserRole { get; set; }
    }
}
