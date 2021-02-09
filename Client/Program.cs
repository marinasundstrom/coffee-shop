using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Components;
using AutoMapper;
using Toolbelt.Blazor.HeadElement;
using Toolbelt.Blazor.Extensions.DependencyInjection;

namespace App1.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.AddHeadElementHelper();

            builder.Services.AddSingleton<AppState>();

            builder.Services.AddSingleton<BrowserInterop>();

            builder.Services.AddSingleton<App1.Client.Cart.ShoppingCartService>();

            builder.Services.AddHttpClient<IProductsClient>(nameof(IProductsClient), (sp, http) =>
            {
                http.BaseAddress = new Uri(sp.GetService<NavigationManager>().BaseUri);
            })
              .AddTypedClient<IProductsClient>((http, sp) => new ProductsClient(http)
              {

              });

            builder.Services.AddHttpClient<IDiscountsClient>(nameof(IDiscountsClient), (sp, http) =>
            {
                http.BaseAddress = new Uri(sp.GetService<NavigationManager>().BaseUri);
            })
              .AddTypedClient<IDiscountsClient>((http, sp) => new DiscountsClient(http)
              {

              });

            builder.Services.AddHttpClient<IShoppingCartClient>(nameof(ShoppingCartClient), (sp, http) =>
            {
                http.BaseAddress = new Uri(sp.GetService<NavigationManager>().BaseUri);
            })
              .AddTypedClient<IShoppingCartClient>((http, sp) => new ShoppingCartClient(http)
              {

              });

            builder.Services.AddHttpClient<ICheckoutClient>(nameof(CheckoutClient), (sp, http) =>
            {
                http.BaseAddress = new Uri(sp.GetService<NavigationManager>().BaseUri);
            })
              .AddTypedClient<ICheckoutClient>((http, sp) => new CheckoutClient(http)
              {

              });

            builder.Services.AddHttpClient<ICategoriesClient>(nameof(CategoriesClient), (sp, http) =>
            {
                http.BaseAddress = new Uri(sp.GetService<NavigationManager>().BaseUri);
            })
              .AddTypedClient<ICategoriesClient>((http, sp) => new CategoriesClient(http)
              {

              });

            builder.Services.AddHttpClient<ICampaignsClient>(nameof(CampaignsClient), (sp, http) =>
            {
                http.BaseAddress = new Uri(sp.GetService<NavigationManager>().BaseUri);
            })
            .AddTypedClient<ICampaignsClient>((http, sp) => new CampaignsClient(http)
            {

            });

            builder.Services.AddHttpClient<ICustomersClient>(nameof(CustomersClient), (sp, http) =>
            {
                http.BaseAddress = new Uri(sp.GetService<NavigationManager>().BaseUri);
            })
            .AddTypedClient<ICustomersClient>((http, sp) => new CustomersClient(http)
            {

            });

            builder.Services.AddHttpClient<IContactsClient>(nameof(ContactsClient), (sp, http) =>
            {
                http.BaseAddress = new Uri(sp.GetService<NavigationManager>().BaseUri);
            })
            .AddTypedClient<IContactsClient>((http, sp) => new ContactsClient(http)
            {

            });

            builder.Services.AddHttpClient<ISourcesClient>(nameof(SourcesClient), (sp, http) =>
            {
                http.BaseAddress = new Uri(sp.GetService<NavigationManager>().BaseUri);
            })
            .AddTypedClient<ISourcesClient>((http, sp) => new SourcesClient(http)
            {

            });

            await builder.Build().RunAsync();
        }
    }
}
