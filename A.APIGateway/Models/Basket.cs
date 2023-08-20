namespace A.APIGateway.Models
{
    public class Basket : BaseEntity
    {
        public string Id { get; set; }

        public List<BasketItem> Items { get; set; } = new();

        public Customer Customer { get; set; }

        public Basket(string id, Customer customer)
        {
            Id = id;
            Customer = customer;
        }
    }
}
