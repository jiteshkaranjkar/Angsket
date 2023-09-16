namespace A.APIGateway.Models
{
    public class OrderItem
    {
        public string Id { get; set; }

        public ProductEntity Product { get; set; }

        public int Quantity { get; set; }

        public OrderItem(string id, ProductEntity product, int quantity)
        {
            Id = id;
            Product = product;
            Quantity = quantity;
        }
    }
}
