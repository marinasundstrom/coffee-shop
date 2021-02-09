using App1.Data;
using App1.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace App1.Application.Discounts.Queries
{
    public class GetDiscountsQuery : IRequest<IEnumerable<DiscountDto>>
    {
        public int? CampaignId { get; set; }

        public class GetDiscountsQueryHandler : IRequestHandler<GetDiscountsQuery, IEnumerable<DiscountDto>>
        {
            private readonly int ContactId = 1;

            private readonly ApplicationDataContext applicationDataContext;
            private readonly IMapper mapper;

            public GetDiscountsQueryHandler(ApplicationDataContext applicationDataContext, IMapper mapper)
            {
                this.applicationDataContext = applicationDataContext;
                this.mapper = mapper;
            }

            public async Task<IEnumerable<DiscountDto>> Handle(GetDiscountsQuery request, CancellationToken cancellationToken)
            {
                cancellationToken.ThrowIfCancellationRequested();

                IQueryable<Discount>? discounts = applicationDataContext.Discounts
                    .Include("Campaign")
                    .Include("Product")
                    .Include("Category")
                    .Include("Product.Category")
                    .Include("ProductVariant")
                    .Include("Images")
                    .Include("Images.Image")
                    //.Where(x => x.ContactId == ContactId)
                    //.Where(x => x.TimesUsed != x.UseLimit)
                    .AsQueryable();

                if (request.CampaignId != null)
                {
                    discounts = discounts.Where(x => x.Campaign!.Id != x.Id);
                }

                return mapper.ProjectTo<DiscountDto>(discounts);
            }
        }
    }
}
