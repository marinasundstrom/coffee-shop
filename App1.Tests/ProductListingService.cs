using App1.Data;
using App1.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace App1.Tests
{
    public class ProductListingService
    {
        private readonly SessionService sessionService;
        private readonly ApplicationDataContext context;

        public ProductListingService(SessionService sessionService, ApplicationDataContext context)
        {
            this.sessionService = sessionService;
            this.context = context;
        }

        public async IAsyncEnumerable<ProductDto> GetProductAsync(Person person)
        {
            // Get all the persons offers

            ShoppingCart? shoppingCart = await context.ShoppingCarts
                .Include(sc => sc.Discounts)
                .FirstOrDefaultAsync();

            Discount[]? offers = await context.Discounts
               .Where(o => (o.Person == null && o.Contact == null) || o.Person == person)
               .ToArrayAsync();

            // Iterate products and check for offer prices

            foreach (Product? product in context.Products)
            {
                List<Discount> offers2 = new List<Discount>();
                List<OfferDto> offerDtos = new List<OfferDto>();

                foreach (Discount offer in offers
                     .Where(x => x.Person == null & x.Contact == null)
                     .Where(o => o.Product == null && o.Category == null)
                     .Where(o => o != null))
                {
                    offers2.Add(offer);

                    offerDtos.Add(new OfferDto()
                    {
                        Name = offer.Name,
                        OfferPrice = offer.FixedPrice,
                        DiscountRate = offer.DiscountRate,
                        DiscountAmount = offer?.DiscountAmount
                    });
                }

                Discount? offer2 = shoppingCart.Discounts
                   .Select(i => i.Discount)
                   .FirstOrDefault(o => (o.Product != null && o.Product == product) || (o.Category != null && o.Category == product.Category));

                if (offer2 != null)
                {
                    offers2.Add(offer2);

                    offerDtos.Add(new OfferDto()
                    {
                        Name = offer2.Name,
                        OfferPrice = offer2.FixedPrice,
                        DiscountRate = offer2.DiscountRate,
                        DiscountAmount = offer2?.DiscountAmount
                    });
                }

                yield return new ProductDto()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = Price(offers2, product),
                    OrdinaryPrice = product.Price,
                    //Currency = product.Price?.Currency?.Code,
                    Offers = offerDtos
                };
            }
        }

        // If there are multiple discounts take the lower

        private static decimal Price(IEnumerable<Discount> offers, Product product)
        {
            decimal price = product.Price;

            foreach (Discount? offer in offers)
            {
                if (!offer.IsDiscountPrice)
                {
                    return offer.FixedPrice.GetValueOrDefault();
                }
                else if (offer.IsDiscountPrice)
                {
                    if (offer.DiscountAmount != null)
                    {
                        price -= offer.DiscountAmount.GetValueOrDefault();
                    }
                    else
                    {
                        price -= (product.Price * (decimal)offer.DiscountRate!);
                    }
                }
            }

            return price < 0 ? 0 : price;
        }
    }
}