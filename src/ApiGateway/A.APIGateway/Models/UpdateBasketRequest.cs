namespace A.APIGateway.Models;

public class UpdateBasketRequest
{
    public string BuyerId { get; set; }

    public IEnumerable<UpdateProductRequestData> Items { get; set; }
}
