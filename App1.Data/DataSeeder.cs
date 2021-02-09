using System;
using System.Threading.Tasks;
using App1.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace App1.Data
{
    public static class DataSeeder
    {
        public static async Task SeedDataAsync(this IServiceProvider serviceProvider)
        {
            using (var context = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<ApplicationDataContext>())
            {
                await context.Database.EnsureDeletedAsync();

                await context.Database.EnsureCreatedAsync();

                var shoppingCart = new ShoppingCart()
                {
                    Session = null
                };

                context.ShoppingCarts.Add(shoppingCart);

                await context.SaveChangesAsync();

                var currency = new Currency()
                {
                    Name = "Swedish krona",
                    NativeName = "Svensk krona",
                    Code = "SEK"
                };

                context.Currencies.Add(currency);

                var country = new Country()
                {
                    Name = "Sweden",
                    NativeName = "Sverige",
                };

                context.Countries.Add(country);

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

                context.Persons.Add(person);

                var parentCategory = new ProductCategory()
                {
                    Name = "All",
                    Description = ""
                };

                context.ProductCategories.Add(parentCategory);


                var productCategory = new ProductCategory()
                {
                    Name = "Coffee",
                    Description = "",
                    Parent = parentCategory
                };

                context.ProductCategories.Add(productCategory);

                var blendAttr = new ProductStringAttributeDefinition
                {
                    Name = "Blend",
                    DataType = DataType.String,
                };

                productCategory.ProductAttributeDefinition.Add(blendAttr);

                var originAttr = new ProductStringAttributeDefinition
                {
                    Name = "Origin",
                    DataType = DataType.String,
                };

                productCategory.ProductAttributeDefinition.Add(blendAttr);

                var productCategory2 = new ProductCategory()
                {
                    Name = "Pastries",
                    Description = "",
                    Parent = parentCategory
                };

                context.ProductCategories.Add(productCategory2);

                var productCategory4 = new ProductCategory()
                {
                    Name = "Tea",
                    Description = "",
                    Parent = parentCategory
                };

                context.ProductCategories.Add(productCategory4);

                var productCategory3 = new ProductCategory()
                {
                    Name = "Misc",
                    Description = "",
                    Parent = parentCategory
                };

                context.ProductCategories.Add(productCategory3);

                var product1 = new Product()
                {
                    Name = "Standard Brew",
                    Description = "Mollbergs Blandning",
                    Price = 28,
                    Category = productCategory
                };

                product1.Images.Add(new ProductImage()
                {
                    Image = new Image() {  ImageId = "coffee2.jpg" }
                });

                context.Products.Add(product1);

                var product2 = new Product()
                {
                    Name = "Special Brew",
                    Description = "Our own blend of roasted coffee beans from Ethiopia.",
                    Price = 27,
                    CompareAtPrice = 32,
                    Category = productCategory
                };

                product2.Images.Add(new ProductImage()
                {
                    Image = new Image() { ImageId = "coffee1.jpg" }
                });

                var attrValue = new ProductStringAttribute()
                {
                    Definition = originAttr,
                    Value = "Ethiopia"
                };

                var attrValue2 = new ProductStringAttribute()
                {
                    Definition = blendAttr,
                    Value = "Arabica"
                };

                product2.Attributes.Add(attrValue);
                product2.Attributes.Add(attrValue2);

                context.Products.Add(product2);

                var product3 = new Product()
                {
                    Name = "Mom's Apple Pie",
                    Description = "Our delicious apples pie with crunchy crumbles and vanilla custard.",
                    Price = 45,
                    Category = productCategory2
                };

                product3.Images.Add(new ProductImage()
                {
                    
                    Image = new Image() { ImageId = "apple-pie.jpg" }
                });

                context.Products.Add(product3);

                var product4 = new Product()
                {
                    Name = "Coffee-to-Go mug",
                    Description = "Bring your coffee with you in this fancy mug.",
                    Category = productCategory3,
                    VariantsTitle = "Color"
                };

                product4.Images.Add(new ProductImage()
                {
                    
                    Image = new Image() { ImageId = "mugs.jpg" }
                });

                product4.Variants.Add(new ProductVariant()
                {
                    Name = "Blue",
                    Description = "Blue mug",
                    SKU = "1234",
                    Price = 82
                });

                product4.Variants.Add(new ProductVariant()
                {
                    Name = "Red",
                    Description = "Red mug",
                    SKU = "4321",
                    Price = 72
                });

                context.Products.Add(product4);

                await context.SaveChangesAsync();

                var product5 = new Product()
                {
                    Name = "Chai Latte",
                    Description = "Tea with milk",
                    Price = 22,
                    Category = productCategory4,
                };

                product5.Images.Add(new ProductImage()
                {
                    
                    Image = new Image() { ImageId = "chai.jpg" }
                });

                context.Products.Add(product5);

                var campaign = new Campaign()
                {
                    Name = "Spring Fika",
                    Description = "Taste",
                    DateThru = DateTime.Now.AddDays(256)
                };

                context.Campaigns.Add(campaign);

                await context.SaveChangesAsync();

                Discount? offer = null;
                offer = new Discount()
                {
                    Product = product2,
                    Person = person,
                    Campaign = campaign,
                    Name = "20% Off Special Brew",
                    Description = "Enjoy a cup of our Special Brew.\nThis is valid 5 times.",
                    IsDiscountPrice = true,
                    DiscountRate = 0.20,
                    ExpirationDate = DateTime.Now.AddDays(256)
                };

                offer.Images.Add(new OfferImage()
                {
                    
                    Image = new Image() { ImageId = "coffee1.jpg" }
                });

                context.Discounts.Add(offer);

                await context.SaveChangesAsync();

                var contact = new Contact()
                {
                    FirstName = "Jane",
                    LastName = "Doe",
                    SSN = "19710523",
                    PhoneNumber = "",
                    EmailAddress = "jane.doe@example.com",
                    Address = new Address()
                    {
                        StreetAddress = "Test Street",
                        StreetNumber = "1",
                        ZipCode = "1243",
                        City = "Teston"
                    },
                    OfferCode = "A1234!"
                };

                context.Contacts.Add(contact);

                var offer2 = new Discount()
                {
                    Product = product1,
                    Contact = contact,
                    Name = "Free coffee for you",
                    Description = "Enjoy a cup of our wonderful Special Brew.",
                    FixedPrice = 0
                };

                offer2.Images.Add(new OfferImage()
                {
                    
                    Image = new Image() { ImageId = "coffee2.jpg" }
                });

                context.Discounts.Add(offer2);

                //var offer3 = new BundleOffer()
                //{
                //    Name = "Mom's Apple Pie and Coffee",
                //    Person = person,
                //    Description = "Taste our delicious Apple Pie together with a cup of our freshly brewed Special Brew.",
                //    Price = 25
                //};

                //offer3.Images.Add(new OfferImage()
                //{                  
                //    Image = new Image() { ImageId = "apple-pie.jpg" }
                //});

                //offer3.BundleOfferItems.Add(new BundleOfferItem()
                //{
                //    Product = product2
                //});

                //offer3.BundleOfferItems.Add(new BundleOfferItem()
                //{
                //    Product = product3
                //});

                //context.Discounts.Add(offer3);

                await context.SaveChangesAsync();

                context.OrderStatus.Add(new OrderStatus()
                {
                    Name = "Ongoing",
                    Description = string.Empty
                });

                context.OrderStatus.Add(new OrderStatus()
                {
                    Name = "Complete",
                    Description = string.Empty
                });

                await context.SaveChangesAsync();

                var order = new Order()
                {
                    OrderDate = DateTime.Now,
                    Person = person,
                    Status = await context.OrderStatus.FirstOrDefaultAsync(),
                    FirstName = "John",
                    LastName = "Doe",
                    SSN = "198403214858",
                    PhoneNumber = "123456789",
                    EmailAddress = "john.doe@example.com",
                    BillingAddress = new Address()
                    {
                        StreetAddress = "Big Street",
                        StreetNumber = "42",
                        ZipCode = "212 20",
                        City = "Motown"
                    },
                    ShippingAddress = new Address()
                    {
                        StreetAddress = "Big Street",
                        StreetNumber = "42",
                        ZipCode = "212 20",
                        City = "Motown"
                    },
                };

                order.OrderItems.Add(new OrderItem()
                {
                    Name = product1.Name,
                    Description = product1.Description,
                    Quantity = 1,
                    Price = product1.Price
                });

                context.Orders.Add(order);

                await context.SaveChangesAsync();
            }
        }
    }
}
