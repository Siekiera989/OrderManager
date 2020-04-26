﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManager.DomainModel;
using OrderManager.DomainModel.Enums;

namespace OrderManager.Infrastructure.DTO
{
    public class CustomerDto
    {
        public Guid CustomerID { get; set; }
        public Company Company { get; set; }
        public Person Person { get; set; }
    }
}