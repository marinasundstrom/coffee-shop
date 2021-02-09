﻿using System.Collections.Generic;
using System.Threading.Tasks;
using App1.Application.Campaigns.Queries;
using App1.Application.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace App1.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CampaignsController : ControllerBase
    {
        private readonly IMediator mediator;

        public CampaignsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<CampaignShortDto>> GetCampaigns()
        {
            return await mediator.Send(new GetCampaignsQuery());
        }
    }
}
