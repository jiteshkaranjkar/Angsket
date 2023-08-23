using System.ComponentModel.DataAnnotations;

namespace A.Domain.Models
{
    public class Buyer : BaseEntity
    {
        public string? Name { get; set; }
        
        public string? LoyaltyCard { get; set; }

        public Address Address { get; set; }

        public Buyer()
        {
            Address = new Address();
        }
    }
}
