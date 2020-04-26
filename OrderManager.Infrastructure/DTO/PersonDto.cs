using OrderManager.DomainModel.Enums;

namespace OrderManager.Infrastructure.DTO
{
    public class PersonDto
    {
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{LastName}, {FirstName}";
        public string EmailAdress { get; set; }
        public string PhoneNumber { get; set; }
        public UserRole UserRole { get; set; }
    }
}
