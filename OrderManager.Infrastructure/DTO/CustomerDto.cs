using OrderManager.DomainModel;

namespace OrderManager.Infrastructure.DTO
{
    public class CustomerDto
    {
        public int CustomerID { get; set; }
        public CompanyDto Company { get; set; }
        public PersonDto Person { get; set; }
    }
}
