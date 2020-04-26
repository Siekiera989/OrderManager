using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderManager.DomainModel;
using OrderManager.DomainModel.Repositories;
using OrderManager.Infrastructure.Config;

namespace OrderManager.Infrastructure.Services
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public OrderRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Order>> GetAllOrders() => await _dbContext.Orders
            .Include(x=>x.Items)
            .ThenInclude(x=>x.Item)
            .Include(x=>x.Customer)
            .Include(x=>x.Employee)
            .ToListAsync();



    }
}
