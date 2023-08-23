namespace A.Domain.Models
{
    public class Address
    {
        public int Id { get; set; }

        public string? Unit { get; set; }

        public string? Street { get; set; }
        
        public string? City { get; set; }

        public string? State { get; set; }

        public string? Country { get; set; }

        public string? ZipCode { get; set; }
    }
}
