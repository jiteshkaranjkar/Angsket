namespace A.Domain.Models
{
    public class Basket : BaseEntity
    {
        public List<Product> Items { get; set; } = new();

        public string Buyerid { get; set; }

        public Basket(string buyerid)
        {
            Created = DateTime.Now;
            Buyerid = buyerid;
        }
    }
}
