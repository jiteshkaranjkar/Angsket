namespace A.APIGateway.Models
{
    public class Customer
    {
        public string Id { get; set; }

        public string? Name { get; set; }
        
        public string? LoyaltyCard { get; set; }

        public Address Address { get; set; }
    }
}
