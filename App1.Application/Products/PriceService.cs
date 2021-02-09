using App1.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App1.Application.Products
{
    public class PriceService
    {
        private readonly DiscountService discountService;

        public PriceService(DiscountService offerService)
        {
            discountService = offerService;
        }

        public async Task<decimal> GetProductPriceAsync(IEnumerable<ShoppingCartDiscount> shoppingCartOffers, Product product)
        {
            IEnumerable<Discount>? generalOffers = await discountService.GetGeneralOffersAsync();

            IEnumerable<Discount>? productOffers = await discountService.GetOffersAsync(shoppingCartOffers, product);

            return CalculateActualPrice(generalOffers.Concat(productOffers), product.Price);
        }

        public async Task<decimal> GetProductPriceAsync(IEnumerable<ShoppingCartDiscount> shoppingCartOffers, ProductVariant productVariant)
        {
            IEnumerable<Discount>? generalDiscounts = await discountService.GetGeneralOffersAsync();

            IEnumerable<Discount>? productOffers = await discountService.GetOffersAsync(shoppingCartOffers, productVariant);

            return CalculateActualPrice(generalDiscounts.Concat(productOffers), productVariant.Price);
        }

        public decimal CalculateActualPrice(IEnumerable<Discount> offers, decimal price)
        {
            foreach (Discount? offer in offers)
            {
                if (!offer.IsDiscountPrice)
                {
                    price = offer.FixedPrice.GetValueOrDefault();
                }
                else if (offer.IsDiscountPrice)
                {
                    if (offer.DiscountAmount != null)
                    {
                        price -= offer.DiscountAmount.GetValueOrDefault();
                    }
                    else if (offer.DiscountRate != null)
                    {
                        price -= price * (decimal)offer.DiscountRate;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }

            return price;
        }
    }
}