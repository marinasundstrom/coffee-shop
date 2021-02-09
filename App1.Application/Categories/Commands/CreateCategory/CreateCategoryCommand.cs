using App1.Data;
using App1.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App1.Application.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<int>
    {
        [Required]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public int? ParentCategoryId { get; set; }

        public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
        {
            private readonly ApplicationDataContext applicationDataContext;
            private readonly IMapper mapper;

            public CreateCategoryCommandHandler(ApplicationDataContext applicationDataContext, IMapper mapper)
            {
                this.applicationDataContext = applicationDataContext;
                this.mapper = mapper;
            }

            public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
            {
                cancellationToken.ThrowIfCancellationRequested();

                var item = mapper.Map<ProductCategory>(request);

                if (request.ParentCategoryId != null)
                {
                    var parentCategory = await applicationDataContext.ProductCategories.FindAsync(request.ParentCategoryId);

                    if(parentCategory == null)
                    {
                        throw new Exception();
                    }

                    item.Parent = parentCategory;
                }
                else
                {
                    item.Parent = await applicationDataContext.ProductCategories.FindAsync(0);
                }

                applicationDataContext.ProductCategories
                    .Add(item);

                await applicationDataContext.SaveChangesAsync();

                return item.Id;
            }
        }
    }
}
