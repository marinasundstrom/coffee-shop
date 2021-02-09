using System;
using AutoMapper;

namespace App1.Client.Admin.Discounts
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<CreateDiscountFormViewModel, App1.Client.CreateDiscount>();
        }
    }
}