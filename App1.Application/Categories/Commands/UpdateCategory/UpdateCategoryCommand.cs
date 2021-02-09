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

namespace App1.Application.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public int? ParentCategoryId { get; set; }

        public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
        {
            private readonly ApplicationDataContext applicationDataContext;
            private readonly IMapper mapper;

            public UpdateCategoryCommandHandler(ApplicationDataContext applicationDataContext, IMapper mapper)
            {
                this.applicationDataContext = applicationDataContext;
                this.mapper = mapper;
            }

            public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
            {
                cancellationToken.ThrowIfCancellationRequested();

                var category = await applicationDataContext.ProductCategories.FindAsync(request.Id);

                if(category == null)
                {
                    throw new Exception();
                }

                category = mapper.Map(request, category);

                if (request.ParentCategoryId != null)
                {
                    if(request.ParentCategoryId == category.Id)
                    {
                        throw new Exception("Cannot have itself as its parent.");
                    }

                    var parentCategory = await applicationDataContext.ProductCategories.FindAsync(request.ParentCategoryId);

                    if(parentCategory == null)
                    {
                        throw new Exception();
                    }

                    category.Parent = parentCategory;
                }

                applicationDataContext.ProductCategories
                    .Update(category);

                await applicationDataContext.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}
