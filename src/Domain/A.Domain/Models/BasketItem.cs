namespace A.Domain.Models
{
    public class BasketItem : BaseEntity
    {
        public string Id { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }

        public BasketItem(string id, Product product, int quantity)
        {
            Id = id;
            Product = product;
            Quantity = quantity;
        }
    }
}
