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
    public class GetCategoryQuery : IRequest<CategoryDto>
    {
        public int Id { get; set; }

        public GetCategoryQuery(int id)
        {
            Id = id;
        }

        public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, CategoryDto>
        {
            private readonly ApplicationDataContext applicationDataContext;
            private readonly IMapper mapper;

            public GetCategoryQueryHandler(ApplicationDataContext applicationDataContext, IMapper mapper)
            {
                this.applicationDataContext = applicationDataContext;
                this.mapper = mapper;
            }

            public async Task<CategoryDto> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
            {
                cancellationToken.ThrowIfCancellationRequested();

                var category = await applicationDataContext.ProductCategories
                    .Include(c => c.Parent)
                    .Include(c => c.ChildCategories)
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

                return mapper.Map<CategoryDto>(category);
            }
        }
    }
}