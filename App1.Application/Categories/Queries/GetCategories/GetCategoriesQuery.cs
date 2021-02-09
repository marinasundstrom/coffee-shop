using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using App1.Data;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App1.Application.Categories.Queries.GetCategories
{
    public class GetCategoriesQuery : IRequest<IEnumerable<CategoryDto>>
    {
        public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, IEnumerable<CategoryDto>>
        {
            private readonly ApplicationDataContext applicationDataContext;
            private readonly IMapper mapper;

            public GetCategoriesQueryHandler(ApplicationDataContext applicationDataContext, IMapper mapper)
            {
                this.applicationDataContext = applicationDataContext;
                this.mapper = mapper;
            }

            public Task<IEnumerable<CategoryDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
            {
                cancellationToken.ThrowIfCancellationRequested();

                var categories = applicationDataContext.ProductCategories
                    .Include(c => c.Parent)
                    .Include(c => c.ChildCategories);

                return Task.FromResult(mapper.ProjectTo<CategoryDto>(categories).AsEnumerable());
            }
        }
    }
}