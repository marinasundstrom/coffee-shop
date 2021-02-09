using System.Collections.Generic;
using System.Threading.Tasks;
using App1.Application.Categories.Commands.CreateCategory;
using App1.Application.Categories.Commands.UpdateCategory;
using App1.Application.Categories.Queries;
using App1.Application.Categories.Queries.GetCategories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace App1.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator mediator;

        public CategoriesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [ResponseCache(Duration = 60)]
        public async Task<IEnumerable<CategoryDto>> GetCategories()
        {
            return await mediator.Send(new GetCategoriesQuery());
        }

        [HttpGet("{id}")]
        [ResponseCache(Duration = 60, VaryByQueryKeys = new[] { "id" })]
        public async Task<CategoryDto> GetCategory(int id)
        {
            return await mediator.Send(new GetCategoryQuery(id));
        }

        [HttpPost]
        public async Task<int> CreateCategory(CreateCategoryCommand command)
        {
            return await mediator.Send(command);
        }
        
        [HttpPut("{id}")]
        [ProducesDefaultResponseType]
        public async Task UpdateCategory(int id, UpdateCategoryCommand command)
        {
            command.Id = id;
            await mediator.Send(command);
        }
    }
}
