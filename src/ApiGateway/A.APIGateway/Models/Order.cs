using A.APIGateway.Common;

namespace A.APIGateway.Models
{
    public class Order
    {
        public string Id { get; set; }

        public int OrderNumber { get; set; }

        public DateTime Date { get; set; }

        public OrderStatus Status { get; set; }

        public decimal Total { get; set; }

        public string? Description { get; set; }

        public Customer Customer { get; set; }

        public List<OrderItem> OrderItems { get; } = new();

        public Order(string id, Customer customer)
        {
            Id = id;
            Customer = customer;
            Date = DateTime.Now;
        }
    }
}
