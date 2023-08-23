namespace A.Domain.Models
{
    public class OrderItem
    {
        public string Id { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }

        public OrderItem(int quantity)
        {
            Id = Guid.NewGuid().ToString();
            Product = new Product();
            Quantity = quantity;
        }
    }
}
