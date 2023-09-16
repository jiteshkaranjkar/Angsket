using System.Configuration;

namespace A.APIGateway.Config
{
    public class UrlsConfig
    {
        public class BasketOperations
        {
            public static string GetItemById(string id) => $"api/vi/basket/{id}";
            public static string UpdateBasket() => $"api/vi/basket";
        }

        public string Basket { get; set; }
        public string GrpcBasket { get; set; }
        public string Product { get; set; }
        public string GrpcProduct { get; set; }
    }
}
