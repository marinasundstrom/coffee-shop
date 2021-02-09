using App1.Application.Common;
using App1.Domain.Entities;
using AutoMapper;

namespace App1.Application.Checkout.Commands
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<CheckOutCommand, Order>();
        }
    }
}
