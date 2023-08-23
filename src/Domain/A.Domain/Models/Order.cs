using A.Domain.Common;

namespace A.Domain.Models
{
    public class Order : BaseEntity
    {
        public string OrderId { get; set; }

        public int OrderNumber { get; set; }

        public OrderStatus Status { get; set; }

        public decimal Total { get; set; }

        public string? Description { get; set; }

        public Buyer Customer { get; set; }

        public List<OrderItem> OrderItems { get; set; }

        public Order()
        {
            OrderId = Guid.NewGuid().ToString();
            Customer = new Buyer();
            Created = DateTime.Now;
            OrderItems = new List<OrderItem>();
        }
    }
}
