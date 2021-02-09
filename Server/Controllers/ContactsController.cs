using System.Collections.Generic;
using System.Threading.Tasks;
using App1.Application.Contacts.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace App1.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ContactsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<ContactDto>> GetContacts()
        {
            return await mediator.Send(new GetContactsQuery());
        }
    }
}
