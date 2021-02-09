using App1.Domain.Entities;
using AutoMapper;

namespace App1.Application.ShoppingCart.Queries
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<ShoppingCartItem, ShoppingCartItemDto>();
        }
    }
}
