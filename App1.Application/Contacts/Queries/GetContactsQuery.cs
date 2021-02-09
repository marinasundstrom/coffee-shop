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

namespace App1.Application.Contacts.Queries
{
    public class GetContactsQuery : IRequest<IEnumerable<ContactDto>>
    {
        public class GetContactsQueryHandler : IRequestHandler<GetContactsQuery, IEnumerable<ContactDto>>
        {
            private int ContactId = 1;

            private readonly ApplicationDataContext applicationDataContext;
            private readonly IMapper mapper;

            public GetContactsQueryHandler(ApplicationDataContext applicationDataContext, IMapper mapper)
            {
                this.applicationDataContext = applicationDataContext;
                this.mapper = mapper;
            }

            public async Task<IEnumerable<ContactDto>> Handle(GetContactsQuery request, CancellationToken cancellationToken)
            {
                cancellationToken.ThrowIfCancellationRequested();

                var persons = applicationDataContext.Contacts
                    .Include(c => c.Source)
                    .AsQueryable();

                return mapper.ProjectTo<ContactDto>(persons);
            }
        }
    }
}
