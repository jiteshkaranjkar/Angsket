using A.BasketRepository;
using A.BasketService.API;
using A.ProductRepository;
//using A.ProductService.API;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDistributedMemoryCache();
builder.Services.AddProductInfrastructure();
builder.Services.AddBasketInfrastructure();
//builder.Services.AddScoped<IProductService, ProductService>();
//builder.Services.AddScoped<IBasketService, BasketService>();
builder.Services.Configure<CookiePolicyOptions>(options =>
{
    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.Unspecified;
    // Handling SameSite cookie according to https://docs.microsoft.com/en-us/aspnet/core/security/samesite?view=aspnetcore-3.1
    options.HandleSameSiteCookieCompatibility();
});
builder.Services.AddOptions();

builder.Services.AddMicrosoftIdentityWebAppAuthentication(builder.Configuration, Constants.AzureAdB2C)
        .EnableTokenAcquisitionToCallDownstreamApi(new string[] { builder.Configuration["TodoList:TodoListScope"] })
        .AddInMemoryTokenCaches();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
