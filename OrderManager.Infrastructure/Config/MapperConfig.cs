using AutoMapper;
using OrderManager.DomainModel;
using OrderManager.Infrastructure.DTO;

namespace OrderManager.Infrastructure.Config
{
    public class MapperConfig
    {
        public IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Company, CompanyDto>();
                cfg.CreateMap<Customer, CustomerDto>();
                cfg.CreateMap<Employee, EmployeeDto>();
                cfg.CreateMap<Item, ItemDto>();
                cfg.CreateMap<Order, OrderDto>();
                cfg.CreateMap<OrderItem, OrderItemDto>();
                cfg.CreateMap<Person, PersonDto>();
            }).CreateMapper();
    }
}
