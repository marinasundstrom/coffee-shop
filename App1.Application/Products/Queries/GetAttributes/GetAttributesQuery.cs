using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using App1.Data;
using App1.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App1.Application.Products.Queries.GetAttributes
{
    public class GetAttributesQuery : IRequest<IQueryable<ProductAttributeDto>>
    {
        public int ProductId { get; set; }

        public GetAttributesQuery(int productId)
        {
            ProductId = productId;
        }

        public class GetAttributesQueryHandler : IRequestHandler<GetAttributesQuery, IQueryable<ProductAttributeDto>>
        {
            private readonly ApplicationDataContext applicationDataContext;
            private readonly IMapper mapper;

            public GetAttributesQueryHandler(ApplicationDataContext applicationDataContext, IMapper mapper)
            {
                this.applicationDataContext = applicationDataContext;
                this.mapper = mapper;
            }

            public async Task<IQueryable<ProductAttributeDto>> Handle(GetAttributesQuery request, CancellationToken cancellationToken)
            {
                cancellationToken.ThrowIfCancellationRequested();

                var product = await applicationDataContext.Products
                    .Include("Attributes")
                    .Include("Attributes.Definition")
                    .FirstOrDefaultAsync(p => p.Id == request.ProductId);

                if (product == null)
                {
                    throw new Exception();
                }

                return product.Attributes.Select<ProductAttribute, ProductAttributeDto>((ProductAttribute a) => {
                    ProductAttributeDto dto;
                    if (a is ProductIntAttribute a2)
                    {
                        dto = mapper.Map<ProductIntAttributeDto>(a);
                        dto.Name = a2.Definition.Name;
                    }
                    else if (a is ProductBoolAttribute b)
                    {
                        dto = mapper.Map<ProductBoolAttributeDto>(a);
                        dto.Name = b.Definition.Name;
                    }
                    else if (a is ProductStringAttribute c)
                    {
                        dto = mapper.Map<ProductStringAttributeDto>(a);
                        dto.Name = c.Definition.Name;
                    }
                    else if (a is ProductEnumAttribute d)
                    {
                        dto = mapper.Map<ProductEnumAttributeDto>(a);
                        dto.Name = d.Definition.Name;
                    }
                    else
                    {
                        return null!;
                    }
                    return dto;
                }).AsQueryable();
            }
        }
    }
}
