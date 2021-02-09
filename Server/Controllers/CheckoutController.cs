using System.Net;
using System.Threading.Tasks;
using App1.Application.Checkout.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App1.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CheckoutController : ControllerBase
    {
        private readonly IMediator mediator;

        public CheckoutController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task Checkout(CheckOutCommand command)
        {
            await mediator.Send(command);
        }
    }
}
