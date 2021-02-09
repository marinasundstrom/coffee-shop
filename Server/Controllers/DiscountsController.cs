using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App1.Application.Discounts.Commands;
using App1.Application.Discounts.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace App1.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiscountsController : ControllerBase
    {
        private readonly IMediator mediator;

        public DiscountsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<DiscountDto>> GetDiscounts([FromQuery] GetDiscountsQuery getDiscountQuery)
        {
            return await mediator.Send(getDiscountQuery);
        }

        [HttpGet("{id}")]
        public async Task<DiscountFullDto> GetDiscount(int id)
        {
            return await mediator.Send((IRequest<DiscountFullDto>)new GetDiscountQuery(id));
        }

        [HttpPost]
        public async Task CreateDiscount(CreateDiscountCommand createDiscountCommand)
        {
            await mediator.Send(createDiscountCommand);
        }
    }
}
