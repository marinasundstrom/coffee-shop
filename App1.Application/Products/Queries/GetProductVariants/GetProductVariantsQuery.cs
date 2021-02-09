using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using App1.Data;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App1.Application.Products.Queries.GetProductVariants
{
    public class GetProductVariantsQuery : IRequest<IQueryable<ProductVariantDto>>
    {
        public int ProductId { get; set; }

        public GetProductVariantsQuery(int productId)
        {
            ProductId = productId;
        }

        public class GetProductVariantsQueryHandler : IRequestHandler<GetProductVariantsQuery, IQueryable<ProductVariantDto>>
        {
            private int ContactId = 1;

            private readonly ApplicationDataContext applicationDataContext;
            private readonly IMapper mapper;

            public GetProductVariantsQueryHandler(ApplicationDataContext applicationDataContext, IMapper mapper)
            {
                this.applicationDataContext = applicationDataContext;
                this.mapper = mapper;
            }

            public Task<IQueryable<ProductVariantDto>> Handle(GetProductVariantsQuery request, CancellationToken cancellationToken)
            {
                cancellationToken.ThrowIfCancellationRequested();

                var productVariants = applicationDataContext.ProductVariants
                    .Include("Images.Image")
                    .Where(pv => pv.ProductId == request.ProductId)
                    .AsQueryable();

                return Task.FromResult(mapper.ProjectTo<ProductVariantDto>(productVariants));
            }
        }
    }
}
