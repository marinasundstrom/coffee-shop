using System;
using System.Threading;
using System.Threading.Tasks;
using App1.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App1.Application.ShoppingCart.Commands
{
    public class UpdateItemQuantityCommand : IRequest
    {
        public int Id { get; set; }
        
        public int Quantity { get; set; }

        public UpdateItemQuantityCommand(int id, int quantity)
        {
            Id = id;
            Quantity = quantity;
        }

        public class UpdateItemQuantityCommandHandler : IRequestHandler<UpdateItemQuantityCommand>
        {
            private readonly ApplicationDataContext applicationDataContext;

            public UpdateItemQuantityCommandHandler(ApplicationDataContext applicationDataContext)
            {
                this.applicationDataContext = applicationDataContext;
            }

            public async Task<Unit> Handle(UpdateItemQuantityCommand request, CancellationToken cancellationToken)
            {
                if(request.Quantity < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                var shoppingCartItem = await applicationDataContext.ShoppingCartItems
                    .FirstOrDefaultAsync(sci => sci.Id == request.Id);

                if (shoppingCartItem == null)
                {
                    throw new Exception();
                }

                if(request.Quantity == 0)
                {
                    applicationDataContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
                else
                {
                    shoppingCartItem.Quantity = request.Quantity;

                    applicationDataContext.Update(shoppingCartItem);
                }

                await applicationDataContext.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}
