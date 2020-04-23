using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManager.DomainModel;
using OrderManager.Infrastructure.DTO;

namespace OrderManager.Infrastructure.Interfaces
{
    public interface IOrderService
    {
        Task<List<OrderDto>> GetAllOrders();
    }
}
