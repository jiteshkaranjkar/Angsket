namespace A.APIGateway.Models
{
    public class Basket : BaseEntity
    {
        public string BuyerId { get; set; }

        public List<Product> Items { get; set; } = new();

        public Basket(string buyerId)
        {
            BuyerId = buyerId;
        }
    }
}
