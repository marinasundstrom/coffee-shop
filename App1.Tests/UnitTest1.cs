using App1.Data;
using App1.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace App1.Tests
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper output;

        public UnitTest1(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public async Task Test1()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDataContext>()
                .UseInMemoryDatabase("Test");

            using (var context = new ApplicationDataContext(optionsBuilder.Options))
            {
                var person = new Person()
                {
                    FirstName = "John",
                    LastName = "Doe",
                    SSN = "198403214858",
                    PhoneNumber = "123456789",
                    EmailAddress = "john.doe@example.com",
                    BillingAddress = new Address2()
                    {
                        StreetAddress = "Big Street",
                        StreetNumber = "42",
                        ZipCode = "212 20",
                        City = "Motown"
                    },
                    ShippingAddress = new Address2()
                    {
                        StreetAddress = "Big Street",
                        StreetNumber = "42",
                        ZipCode = "212 20",
                        City = "Motown"
                    },
                };

                await context.Persons.AddAsync(person);

                var product = new Product()
                {
                    Name = "Pen",
                    Price = 12
                };

                await context.Products.AddAsync(product);

                var product2 = new Product()
                {
                    Name = "Toilettpaper x 10",
                    Price = 100
                };

                await context.Products.AddAsync(product2);

                var offer = new Discount()
                {
                    Name = "15 SEK OFF",
                    Product = product,
                    DiscountAmount = 15
                };

                await context.Discounts.AddAsync(offer);

                var offer2 = new Discount()
                {
                    Name = "20% OFF",
                    DiscountRate = 0.20
                };

                await context.Discounts.AddAsync(offer2);

                var shoppingCart = new ShoppingCart()
                {
                   
                };

                await context.ShoppingCarts.AddAsync(shoppingCart);

                var shoppingCartItem = new ShoppingCartItem()
                {
                    Product = product,
                    Quantity = 1
                };

                shoppingCart.Items.Add(shoppingCartItem);

                var shoppingCartOffer = new ShoppingCartDiscount()
                {
                    Discount = offer
                };

                shoppingCart.Discounts.Add(shoppingCartOffer);

                await context.SaveChangesAsync();

                var productService = new ProductListingService(new SessionService(context), context);
                await foreach (var p in productService.GetProductAsync(person))
                {
                    //if(p.OfferPrice == null)
                    //{
                    //    output.WriteLine($"{p.Name} - {p.Price} {p.Currency}");
                    //}
                    //else
                    //{
                    //    output.WriteLine($"{p.Name} - {p.OfferPrice} {p.Currency} ({p.Price} {p.Currency})");
                    //}

                    output.WriteLine(System.Text.Json.JsonSerializer.Serialize(p, new JsonSerializerOptions
                    {
                        WriteIndented = true
                    }));
                }
            }
        }
    }
}