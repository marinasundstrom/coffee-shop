using System.Collections.Generic;
using System.Threading.Tasks;
using App1.Application.ShoppingCart.Commands;
using App1.Application.ShoppingCart.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App1.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IMediator mediator;

        public ShoppingCartController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ShoppingCartDto> GetShoppingCart()
        {
            return await mediator.Send(new GetCartQuery());
        }

        [HttpGet("Price")]
        public async Task<ShoppingCartPriceDto> GetPrice()
        {
            return await mediator.Send(new GetPriceQuery());
        }

        [HttpGet("Items")]
        public async Task<IEnumerable<ShoppingCartItemDto>> GetShoppingCartItems()
        {
            return await mediator.Send(new GetItemsQuery());
        }

        [HttpGet("Items/Count")]
        public async Task<int> GetItemsCount()
        {
            return await mediator.Send(new GetItemsCountQuery());
        }

        [HttpPost]
        public async Task<ShoppingCartItemDto> AddShoppingCartItem([FromQuery] AddItemCommand command)
        {
            return await mediator.Send(command);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task UpdateItemQuantity(int id, int quantity)
        {
            await mediator.Send(new UpdateItemQuantityCommand(id, quantity));
        }

        [HttpDelete("{id}")]
        public async Task RemoveShoppingCartItem(int id)
        {
            await mediator.Send(new RemoveItemCommand(id));
        }

        [HttpDelete]
        public async Task ClearShoppingCart()
        {
            await mediator.Send(new ClearCommand());
        }
    }
}
