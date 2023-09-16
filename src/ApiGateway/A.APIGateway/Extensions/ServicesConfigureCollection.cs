using A.APIGateway.Config;
using A.APIGateway.Infrastructure;
using A.APIGateway.Services.Concretes;
using A.APIGateway.Services.Contracts;
using GrpcBasket;
using GrpcProduct;
using Microsoft.Extensions.Options;

namespace A.APIGateway.Extensions
{
    internal static class ServicesConfigureCollection
    {
        public static IServiceCollection AddGrpcServices(this IServiceCollection services)
        {
            services.AddTransient<GrpcExceptionInterceptor>();
            services.AddScoped<IBasketService, BasketService>();
            services.AddGrpcClient<Basket.BasketClient>((services, options) =>
            {
                var basketApi = services.GetRequiredService<IOptions<UrlsConfig>>().Value.GrpcBasket;
            }).AddInterceptor<GrpcExceptionInterceptor>();

            //services.AddScoped<IProductService, ProductService>();
            services.AddGrpcClient<Product.ProductClient>((services, options) =>
            {
                var basketApi = services.GetRequiredService<IOptions<UrlsConfig>>().Value.GrpcProduct;
            }).AddInterceptor<GrpcExceptionInterceptor>();
            return services;
        }
    }
}
