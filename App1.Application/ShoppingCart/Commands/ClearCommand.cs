using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using App1.Data;
using App1.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App1.Application.ShoppingCart.Commands
{
    public class ClearCommand : IRequest
    {
        public class ClearCommandHandler : IRequestHandler<ClearCommand>
        {
            private readonly ApplicationDataContext applicationDataContext;

            public ClearCommandHandler(ApplicationDataContext applicationDataContext)
            {
                this.applicationDataContext = applicationDataContext;
            }

            public async Task<Unit> Handle(ClearCommand request, CancellationToken cancellationToken)
            {
                var shoppingCart = await applicationDataContext
                    .ShoppingCarts
                    .Include(sc => sc.Items)
                    .FirstAsync();

                foreach(var item in shoppingCart.Items.ToArray())
                {
                    applicationDataContext.ShoppingCartItems.Remove(item);
                }

                await applicationDataContext.SaveChangesAsync();

                return await Unit.Task;
            }
        }
    }
}
