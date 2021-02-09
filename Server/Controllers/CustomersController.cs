using System.Collections.Generic;
using System.Threading.Tasks;
using App1.Application.Campaigns.Queries;
using App1.Application.Common;
using App1.Application.Customers.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace App1.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator mediator;

        public CustomersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<CustomerDto>> GetCustomers()
        {
            return await mediator.Send(new GetCustomersQuery());
        }
    }
}
