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

namespace App1.Application.Customers.Queries
{
    public class GetCustomersQuery : IRequest<IEnumerable<CustomerDto>>
    {
        public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, IEnumerable<CustomerDto>>
        {
            private int ContactId = 1;

            private readonly ApplicationDataContext applicationDataContext;
            private readonly IMapper mapper;

            public GetCustomersQueryHandler(ApplicationDataContext applicationDataContext, IMapper mapper)
            {
                this.applicationDataContext = applicationDataContext;
                this.mapper = mapper;
            }

            public async Task<IEnumerable<CustomerDto>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
            {
                cancellationToken.ThrowIfCancellationRequested();

                var persons = applicationDataContext.Persons
                    .AsQueryable()
                    .Include(c => c.Addresses)
                    .Include(c => c.BillingAddress)
                    .Include(c => c.ShippingAddress);

                return mapper.ProjectTo<CustomerDto>(persons);
            }
        }
    }
}
