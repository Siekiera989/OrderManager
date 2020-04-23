using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OrderManager.DomainModel;
using OrderManager.DomainModel.Enums;
using OrderManager.DomainModel.Repositories;
using OrderManager.Infrastructure.Config;
using OrderManager.Infrastructure.DTO;
using OrderManager.Infrastructure.Interfaces;

namespace OrderManager.Infrastructure.Services
{
    public class OrderRepository:IOrderRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public OrderRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Order>> GetAllOrders() 
            => await _dbContext.Orders
                .Include(x=>x.Items)
                .Include(x=>x.Employee)
                .Include(x=>x.Customer)
                .ToListAsync();
    }
}
