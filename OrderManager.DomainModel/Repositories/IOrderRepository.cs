using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderManager.DomainModel.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>>  GetAllOrders();
    }
}
