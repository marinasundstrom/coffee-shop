using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using App1.Data;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App1.Application.ShoppingCart.Queries
{
    public class GetItemsQuery : IRequest<IQueryable<ShoppingCartItemDto>>
    {
        public class GetItemsQueryHandler : IRequestHandler<GetItemsQuery, IQueryable<ShoppingCartItemDto>>
        {
            private readonly ApplicationDataContext applicationDataContext;
            private readonly IMapper mapper;

            public GetItemsQueryHandler(ApplicationDataContext applicationDataContext, IMapper mapper)
            {
                this.applicationDataContext = applicationDataContext;
                this.mapper = mapper;
            }

            public Task<IQueryable<ShoppingCartItemDto>> Handle(GetItemsQuery request, CancellationToken cancellationToken)
            {
                cancellationToken.ThrowIfCancellationRequested();

                var shoppingCartItems = applicationDataContext.ShoppingCartItems
                    .Include("Product")
                    .Include("ProductVariant")
                    .Include("Discount");

                return Task.FromResult(mapper.ProjectTo<ShoppingCartItemDto>(shoppingCartItems));
            }
        }
    }
}
