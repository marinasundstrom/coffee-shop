using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using App1.Application.Common;
using App1.Data;
using AutoMapper;
using MediatR;

namespace App1.Application.Campaigns.Queries
{
    public class GetCampaignsQuery : IRequest<IQueryable<CampaignShortDto>>
    {
        public int? CampaignId { get; set; }

        public class GetCampaignsQueryHandler : IRequestHandler<GetCampaignsQuery, IQueryable<CampaignShortDto>>
        {
            private readonly ApplicationDataContext applicationDataContext;
            private readonly IMapper mapper;

            public GetCampaignsQueryHandler(ApplicationDataContext applicationDataContext, IMapper mapper)
            {
                this.applicationDataContext = applicationDataContext;
                this.mapper = mapper;
            }

            public Task<IQueryable<CampaignShortDto>> Handle(GetCampaignsQuery request, CancellationToken cancellationToken)
            {
                cancellationToken.ThrowIfCancellationRequested();

                var campaigns = applicationDataContext.Campaigns
                    .AsQueryable();

                return Task.FromResult(mapper.ProjectTo<CampaignShortDto>(campaigns));
            }
        }
    }
}
