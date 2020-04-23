using AutoMapper;
using OrderManager.DomainModel;
using OrderManager.Infrastructure.DTO;

namespace OrderManager.Infrastructure.Config
{
    public static class MapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<OrderDto, Order>();
                cfg.CreateMap<EmployeeDto, Employee>();
                cfg.CreateMap<CompanyDto, Company>();
            }).CreateMapper();
    }
}
