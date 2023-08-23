namespace A.Domain.Models
{
    public class Basket : BaseEntity
    {
        public string BasketId { get; set; }

        public List<BasketItem> Items { get; set; } = new();

        public Buyer Customer { get; set; }

        public Basket()
        {
            BasketId = Guid.NewGuid().ToString();
            Customer = new Buyer();
            Created = DateTime.Now;
            Items = new List<BasketItem>();
        }
    }
}
