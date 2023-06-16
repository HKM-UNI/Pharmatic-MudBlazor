using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Pharmatic;
using Pharmatic.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
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
builder.Services.AddScoped<ProductCompositionService>();
builder.Services.AddScoped<LotService>();

builder.Services.AddScoped<SharedData>();

await builder.Build().RunAsync();
