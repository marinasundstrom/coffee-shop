using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using App1.Data;
using App1.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App1.Application.Discounts.Queries
{
    public class GetDiscountQuery : IRequest<DiscountFullDto>
    {
        public int Id { get; set; }

        public GetDiscountQuery(int id)
        {
            Id = id;
        }

        public class GetDiscountQueryHandler : IRequestHandler<GetDiscountQuery, DiscountFullDto>
        {
            private readonly ApplicationDataContext applicationDataContext;
            private readonly IMapper mapper;

            public GetDiscountQueryHandler(ApplicationDataContext applicationDataContext, IMapper mapper)
            {
                this.applicationDataContext = applicationDataContext;
                this.mapper = mapper;
            }

            public async Task<DiscountFullDto> Handle(GetDiscountQuery request, CancellationToken cancellationToken)
            {
                cancellationToken.ThrowIfCancellationRequested();

                var discount = applicationDataContext.Discounts
                    .Include("Campaign")
                    .Include("Product")
                    .Include("ProductCategory")
                    .Include("Product.Category")
                    .Include("ProductVariant")
                    .Include("Images")
                    .Include("Images.Image")
                    .FirstOrDefault(p => p.Id == request.Id);

                return mapper.Map<DiscountFullDto>(discount);
            }
        }
    }
}
