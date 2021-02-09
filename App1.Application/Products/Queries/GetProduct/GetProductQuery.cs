using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using App1.Data;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App1.Application.Products.Queries.GetProduct
{
    public class GetProductQuery : IRequest<ProductDto>
    {
        public int ProductId { get; set; }

        public GetProductQuery(int productId)
        {
            ProductId = productId;
        }

        public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductDto>
        { 
            private readonly ApplicationDataContext applicationDataContext;
            private readonly IMapper mapper;
            private readonly ProductListingService productListingService;

            public GetProductQueryHandler(ApplicationDataContext applicationDataContext, IMapper mapper, ProductListingService productListingService)
            {
                this.productListingService = productListingService;
                this.applicationDataContext = applicationDataContext;
                this.mapper = mapper;
            }

            public async Task<ProductDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
            {
                cancellationToken.ThrowIfCancellationRequested();

                return await productListingService.GetProductAsync(request.ProductId);
            }
        }
    }
}
