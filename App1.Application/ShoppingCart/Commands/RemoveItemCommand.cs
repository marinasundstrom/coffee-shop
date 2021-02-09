using System;
using System.Threading;
using System.Threading.Tasks;
using App1.Data;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App1.Application.ShoppingCart.Commands
{
    public class RemoveItemCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveItemCommand(int id)
        {
            Id = id;
        }

        public class RemoveItemCommandHandler : IRequestHandler<RemoveItemCommand>
        {
            private readonly ApplicationDataContext applicationDataContext;

            public RemoveItemCommandHandler(ApplicationDataContext applicationDataContext)
            {
                this.applicationDataContext = applicationDataContext;
            }

            public async Task<Unit> Handle(RemoveItemCommand request, CancellationToken cancellationToken)
            {
                var shoppingCartItem = await applicationDataContext.ShoppingCartItems
                    .FirstOrDefaultAsync(sci => sci.Id == request.Id);

                if(shoppingCartItem == null)
                {
                    throw new Exception();
                }

                applicationDataContext.ShoppingCartItems.Remove(shoppingCartItem);

                await applicationDataContext.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}
