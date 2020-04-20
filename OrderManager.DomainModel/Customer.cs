using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.DomainModel
{
    public class Customer:Person
    {
        public Company Company { get; set; }
    }
}
