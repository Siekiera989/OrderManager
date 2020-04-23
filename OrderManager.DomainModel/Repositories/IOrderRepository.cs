using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.DomainModel.Repositories
{
    public interface IOrderRepository
    {
        Task<List<Order>>  GetAllOrders();
    }
}
