using System.Threading;
using System.Threading.Tasks;
using App1.Application.Products;
using App1.Data;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App1.Application.ShoppingCart.Queries
{
    public class GetPriceQuery : IRequest<ShoppingCartPriceDto>
    {
        public class GetPriceQueryHandler : IRequestHandler<GetPriceQuery, ShoppingCartPriceDto>
        {
            private readonly ApplicationDataContext applicationDataContext;
            private readonly IMapper mapper;
            private readonly PriceService priceService;

            public GetPriceQueryHandler(ApplicationDataContext applicationDataContext, IMapper mapper, PriceService priceService)
            {
                this.applicationDataContext = applicationDataContext;
                this.mapper = mapper;
                this.priceService = priceService;
            }

            public async Task<ShoppingCartPriceDto> Handle(GetPriceQuery request, CancellationToken cancellationToken)
            {
                cancellationToken.ThrowIfCancellationRequested();

                var shoppingCart = await applicationDataContext
                    .ShoppingCarts
                    .AsQueryable()
                    .Include(sc => sc.Discounts)
                    .FirstAsync();

                var items = await applicationDataContext.ShoppingCartItems
                    .Include(sci => sci.Product)
                    .Include(sci => sci.ProductVariant)
                    .Include(sci => sci.Discount)
                    .ToListAsync();

                decimal total = 0;

                foreach(var item in items)
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

                return new ShoppingCartPriceDto()
                {
                    Total = total
                };
            }
        }
    }
}
