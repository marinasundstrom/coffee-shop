using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using App1.Data;
using App1.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App1.Application.Products.Queries.GetProducts
{
    public class GetProductsQuery : IRequest<IAsyncEnumerable<ProductDto>>
    {
        public int? CategoryId { get; set; }

        public GetProductsQuery(int? categoryId)
        {
            CategoryId = categoryId;
        }

        public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IAsyncEnumerable<ProductDto>>
        {
            private readonly ApplicationDataContext dataContext;
            private readonly IMapper mapper;
            private readonly ProductListingService productListingService;

            public GetProductsQueryHandler(ApplicationDataContext dataContext, IMapper mapper, ProductListingService productListingService)
            {
                this.dataContext = dataContext;
                this.mapper = mapper;
                this.productListingService = productListingService;
            }

            public Task<IAsyncEnumerable<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
            {
                cancellationToken.ThrowIfCancellationRequested();

                return Task.FromResult(productListingService.GetProductsAsync(request.CategoryId, cancellationToken));
            }
        }
    }
}
