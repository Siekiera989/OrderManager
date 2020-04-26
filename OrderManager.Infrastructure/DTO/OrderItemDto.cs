using OrderManager.DomainModel;

namespace OrderManager.Infrastructure.DTO
{
    public class OrderItemDto
    {
        public int OrderItemID { get; set; }
        public decimal Amount { get; set; }
        public ItemDto Item { get; set; }
    }
}
