using App1.Application.Products;
using App1.Application.ShoppingCart.Queries;
using App1.Data;
using App1.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace App1.Application.ShoppingCart.Commands
{
    public class AddItemCommand : IRequest<ShoppingCartItemDto>
    {
        public int? ProductId { get; set; }

        public int? ProductVariantId { get; set; }

        public int? OfferId { get; set; }

        public int? PriceId { get; set; }

        public int Quantity { get; set; } = 1;

        public class AddItemCommandHandler : IRequestHandler<AddItemCommand, ShoppingCartItemDto>
        {
            private readonly ApplicationDataContext applicationDataContext;
            private readonly PriceService priceService;
            private readonly IMapper mapper;

            public AddItemCommandHandler(ApplicationDataContext applicationDataContext, PriceService priceService, IMapper mapper)
            {
                this.applicationDataContext = applicationDataContext;
                this.priceService = priceService;
                this.mapper = mapper;
            }

            public async Task<ShoppingCartItemDto> Handle(AddItemCommand request, CancellationToken cancellationToken)
            {
                if (request.Quantity < 0)
                {
                    throw new Exception();
                }

                Domain.Entities.ShoppingCart? shoppingCart = await applicationDataContext
                    .ShoppingCarts
                    .AsQueryable()
                    .Include(sc => sc.Discounts)
                    .Include(sc => sc.Items)
                    .FirstAsync();

                Discount? discount = await applicationDataContext.Discounts.FindAsync(request.OfferId);

                Product? product = await applicationDataContext.Products
                    .FirstOrDefaultAsync(p => p.Id == request.ProductId);

                ProductVariant? productVariant = await applicationDataContext.ProductVariants.FindAsync(request.ProductVariantId);

                if (discount != null)
                {
                    if (request.ProductId != null)
                    {
                        throw new Exception();
                    }
                }
                else
                {
                    if (productVariant != null)
                    {

                    }
                    else
                    {
                        if (product != null)
                        {

                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                }

                ShoppingCartItem? shoppingCartItem = shoppingCart.Items
                    .FirstOrDefault(sci => sci.Product == product && sci.ProductVariant == productVariant);


                if (shoppingCartItem != null)
                {
                    shoppingCartItem.Quantity += request.Quantity;
                }
                else
                {
                    shoppingCartItem = new ShoppingCartItem()
                    {
                        Product = product,
                        ProductVariant = productVariant,
                        Quantity = request.Quantity,
                    };

                    shoppingCart.Items.Add(shoppingCartItem);
                }

                await applicationDataContext.SaveChangesAsync();

                ShoppingCartItemDto? dto = mapper.Map<ShoppingCartItemDto>(shoppingCartItem);

                if (productVariant != null)
                {
                    dto.Price = await priceService.GetProductPriceAsync(shoppingCart.Discounts, productVariant) * request.Quantity;
                }
                else
                {
                    dto.Price = await priceService.GetProductPriceAsync(shoppingCart.Discounts, product) * request.Quantity;
                }

                return dto;
            }
        }
    }
}
