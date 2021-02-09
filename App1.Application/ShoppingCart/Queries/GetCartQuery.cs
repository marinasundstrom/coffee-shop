using App1.Application.Products;
using App1.Data;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace App1.Application.ShoppingCart.Queries
{
    public class GetCartQuery : IRequest<ShoppingCartDto>
    {
        public class GetCartQueryHandler : IRequestHandler<GetCartQuery, ShoppingCartDto>
        {
            private readonly ApplicationDataContext applicationDataContext;
            private readonly IMapper mapper;
            private readonly PriceService priceService;

            public GetCartQueryHandler(ApplicationDataContext applicationDataContext, IMapper mapper, PriceService priceService)
            {
                this.applicationDataContext = applicationDataContext;
                this.mapper = mapper;
                this.priceService = priceService;
            }

            public async Task<ShoppingCartDto> Handle(GetCartQuery request, CancellationToken cancellationToken)
            {
                cancellationToken.ThrowIfCancellationRequested();

                Domain.Entities.ShoppingCart? shoppingCart = await applicationDataContext
                    .ShoppingCarts
                    .AsQueryable()
                    .Include(sc => sc.Discounts)
                    .FirstAsync();

                System.Collections.Generic.IEnumerable<Domain.Entities.ShoppingCartItem>? shoppingCartItems = applicationDataContext.ShoppingCartItems
                    .Include(sci => sci.Product)
                    .Include(sci => sci.ProductVariant)
                    .AsEnumerable();

                decimal total = 0;

                foreach (Domain.Entities.ShoppingCartItem? item in shoppingCartItems)
                {
                    if (item.ProductVariant != null)
                    {
                        total += await priceService.GetProductPriceAsync(shoppingCart.Discounts, item.ProductVariant) * item.Quantity;
                    }
                    else
                    {
                        total += await priceService.GetProductPriceAsync(shoppingCart.Discounts, item.Product) * item.Quantity;
                    }
                }

                return new ShoppingCartDto()
                {
                    Items = mapper.ProjectTo<ShoppingCartItemDto>(shoppingCartItems.AsQueryable()),
                    Total = total
                };
            }
        }
    }
}
