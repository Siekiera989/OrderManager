using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using OrderManager.DomainModel.Repositories;
using OrderManager.Infrastructure.Config;
using OrderManager.Infrastructure.DTO;
using OrderManager.Infrastructure.Interfaces;

namespace OrderManager.Infrastructure.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, MapperConfig mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper.Initialize();
        }
        public async Task<IEnumerable<OrderDto>> GetAllOrders()
        {
            var orders = await _orderRepository.GetAllOrders();
           return _mapper.Map<IEnumerable<OrderDto>>(orders);
        }
    }
}
