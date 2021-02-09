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

namespace App1.Application.Sources.Queries
{
    public class GetSourcesQuery : IRequest<IEnumerable<SourceDto>>
    {
        public class GetSourcesQueryHandler : IRequestHandler<GetSourcesQuery, IEnumerable<SourceDto>>
        {
            private int ContactId = 1;

            private readonly ApplicationDataContext applicationDataContext;
            private readonly IMapper mapper;

            public GetSourcesQueryHandler(ApplicationDataContext applicationDataContext, IMapper mapper)
            {
                this.applicationDataContext = applicationDataContext;
                this.mapper = mapper;
            }

            public async Task<IEnumerable<SourceDto>> Handle(GetSourcesQuery request, CancellationToken cancellationToken)
            {
                cancellationToken.ThrowIfCancellationRequested();

                var persons = applicationDataContext.Sources
                    .AsQueryable();

                return mapper.ProjectTo<SourceDto>(persons);
            }
        }
    }
}
