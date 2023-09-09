using System.ComponentModel.DataAnnotations;

namespace A.APIGateway.Models
{
    public class Product : BaseEntity
    {
        public string? Name { get; set; }
        public string? Brand { get; set; }
        public string? Type { get; set; }
        public string? Description { get; set; }

        public double UnitPrice { get; set; }
        public double PromtionalUnitPrice { get; set; } = 0;

        public string? ImageURL { get; set; }

        public string? Promotion { get; set; }
        public string? PromotionDescription { get; set; }

        public int StockQuantity { get; set; } = 0;
        public int BasketQuantity { get; set; } = 0;
    }
}
