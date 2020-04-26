using OrderManager.DomainModel;

namespace OrderManager.Infrastructure.DTO
{
    public class EmployeeDto
    {
        public int EmployeeID { get; set; }
        public string EmployeeNumber { get; set; } 
        public string Password { get; set; }
        public PersonDto Person { get; set; }
    }
}
