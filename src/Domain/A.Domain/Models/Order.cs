using A.Domain.Common;

namespace A.Domain.Models
{
    public class Order
    {
        public string Id { get; set; }

        public int OrderNumber { get; set; }

        public DateTime Date { get; set; }

        public OrderStatus Status { get; set; }

        public decimal Total { get; set; }

        public string? Description { get; set; }

        public Buyer Customer { get; set; }

        public List<OrderItem> OrderItems { get; set; }

        public Order()
        {
            Id = Guid.NewGuid().ToString();
            Customer = new Buyer();
            Date = DateTime.Now;
            OrderItems = new List<OrderItem>();
        }
    }
}
