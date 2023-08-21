namespace A.APIGateway.Models
{
    public class OrderItem
    {
        public string Id { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }

        public OrderItem(string id, Product product, int quantity)
        {
            Id = id;
            Product = product;
            Quantity = quantity;
        }
    }
}
