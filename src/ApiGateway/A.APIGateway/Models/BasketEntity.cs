namespace A.APIGateway.Models
{
    public class BasketEntity : BaseEntity
    {
        public string BuyerId { get; set; }

        public List<ProductEntity> Items { get; set; } = new();

        public BasketEntity(string buyerId)
        {
            BuyerId = buyerId;
        }
    }
}
