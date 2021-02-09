using System;
using AutoMapper;

namespace App1.Client.Checkout
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<CheckoutFormModel, CheckOut>();
            CreateMap<Common.Address, Client.Address>();
        }
    }
}
