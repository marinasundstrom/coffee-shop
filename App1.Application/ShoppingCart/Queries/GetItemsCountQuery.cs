using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using App1.Data;
using AutoMapper;
using MediatR;

namespace App1.Application.ShoppingCart.Queries
{
    public class GetItemsCountQuery : IRequest<int>
    {
        public class GetItemsCountQueryHandler : IRequestHandler<GetItemsCountQuery, int>
        {
            private readonly ApplicationDataContext applicationDataContext;
            private readonly IMapper mapper;

            public GetItemsCountQueryHandler(ApplicationDataContext applicationDataContext, IMapper mapper)
            {
                this.applicationDataContext = applicationDataContext;
                this.mapper = mapper;
            }

            public Task<int> Handle(GetItemsCountQuery request, CancellationToken cancellationToken)
            {
                cancellationToken.ThrowIfCancellationRequested();

                return Task.FromResult(applicationDataContext.ShoppingCartItems.Sum(x => x.Quantity));
            }
        }
    }
}
