namespace A.Domain.Models
{
    public class Basket : BaseEntity
    {
        public string Id { get; set; }

        public List<BasketItem> Items { get; set; } = new();

        public Buyer Customer { get; set; }

        public Basket(string id, Buyer customer)
        {
            Id = id;
            Customer = customer;
        }
    }
}
