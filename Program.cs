using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Pharmatic;
using Pharmatic.Services;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Pharmatic.Authorization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var baseUrl = builder.Configuration.GetValue<string>("BaseUrl")!;
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseUrl) });
builder.Services.AddMudServices();

builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<SubCategoryService>();
builder.Services.AddScoped<TagService>();
builder.Services.AddScoped<MeasureService>();
builder.Services.AddScoped<RouteOfAdministrationService>();
builder.Services.AddScoped<TypeDoseService>();
builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<ProviderService>();
builder.Services.AddScoped<LotService>();
builder.Services.AddScoped<SalesService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<MetricsService>();

builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
builder.Services.AddAuthorizationCore();

builder.Services.AddAuthorizationCore(options =>
{
    // Pol�ticas para los scopes de provider
    options.AddPolicy("ProviderRead", AuthorizationPolicies.CreateScopeAuthorizationPolicy("provider:read"));
    options.AddPolicy("ProviderWrite", AuthorizationPolicies.CreateScopeAuthorizationPolicy("provider:write"));
    options.AddPolicy("ProviderDelete", AuthorizationPolicies.CreateScopeAuthorizationPolicy("provider:delete"));

    // Pol�ticas para los scopes de customer
    options.AddPolicy("CustomerRead", AuthorizationPolicies.CreateScopeAuthorizationPolicy("customer:read"));
    options.AddPolicy("CustomerWrite", AuthorizationPolicies.CreateScopeAuthorizationPolicy("customer:write"));
    options.AddPolicy("CustomerDelete", AuthorizationPolicies.CreateScopeAuthorizationPolicy("customer:delete"));

    // Pol�ticas para los scopes de product
    options.AddPolicy("ProductRead", AuthorizationPolicies.CreateScopeAuthorizationPolicy("product:read"));
    options.AddPolicy("ProductWrite", AuthorizationPolicies.CreateScopeAuthorizationPolicy("product:write"));
    options.AddPolicy("ProductDelete", AuthorizationPolicies.CreateScopeAuthorizationPolicy("product:delete"));

    // Pol�ticas para los scopes de inventory
    options.AddPolicy("InventoryRead", AuthorizationPolicies.CreateScopeAuthorizationPolicy("inventory:read"));
    options.AddPolicy("InventoryWrite", AuthorizationPolicies.CreateScopeAuthorizationPolicy("inventory:write"));
    options.AddPolicy("InventoryDelete", AuthorizationPolicies.CreateScopeAuthorizationPolicy("inventory:delete"));

    // Pol�ticas para los scopes de sales
    options.AddPolicy("SalesRead", AuthorizationPolicies.CreateScopeAuthorizationPolicy("sales:read"));
    options.AddPolicy("SalesWrite", AuthorizationPolicies.CreateScopeAuthorizationPolicy("sales:write"));
    options.AddPolicy("SalesDelete", AuthorizationPolicies.CreateScopeAuthorizationPolicy("sales:delete"));

    // Pol�ticas para los scopes de purchase
    options.AddPolicy("PurchaseRead", AuthorizationPolicies.CreateScopeAuthorizationPolicy("purchase:read"));
    options.AddPolicy("PurchaseWrite", AuthorizationPolicies.CreateScopeAuthorizationPolicy("purchase:write"));
    options.AddPolicy("PurchaseDelete", AuthorizationPolicies.CreateScopeAuthorizationPolicy("purchase:delete"));

    // Pol�ticas para los scopes de returns
    options.AddPolicy("ReturnsRead", AuthorizationPolicies.CreateScopeAuthorizationPolicy("returns:read"));
    options.AddPolicy("ReturnsWrite", AuthorizationPolicies.CreateScopeAuthorizationPolicy("returns:write"));
    options.AddPolicy("ReturnsDelete", AuthorizationPolicies.CreateScopeAuthorizationPolicy("returns:delete"));

    // Pol�ticas para los scopes de user
    options.AddPolicy("UserRead", AuthorizationPolicies.CreateScopeAuthorizationPolicy("user:read"));
    options.AddPolicy("UserWrite", AuthorizationPolicies.CreateScopeAuthorizationPolicy("user:write"));
    options.AddPolicy("UserDelete", AuthorizationPolicies.CreateScopeAuthorizationPolicy("user:delete"));
});

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped<SharedData>();
builder.Services.AddScoped<ScopeService>();

await builder.Build().RunAsync();