using System.Collections.Generic;
using System.Threading.Tasks;
using App1.Application.Sources.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace App1.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SourcesController : ControllerBase
    {
        private readonly IMediator mediator;

        public SourcesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<SourceDto>> GetSources()
        {
            return await mediator.Send(new GetSourcesQuery());
        }
    }
}
