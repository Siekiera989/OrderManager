using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.DomainModel
{
    public enum Status
    {
        Cancelled = 0,
        Received = 1,
        Confirmed = 3,
        InProgress = 5,
        Delayed = 7,
        Completed = 9
    }
}
