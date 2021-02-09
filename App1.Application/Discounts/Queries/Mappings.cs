using App1.Application.Common;
using App1.Domain.Entities;
using AutoMapper;

namespace App1.Application.Discounts.Queries
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<Discount, DiscountDto>();

            CreateMap<Currency, string>().ConvertUsing(x => x.Code);

            CreateMap<OfferImage, ImageDto>()
               .ForMember(m => m.ImageId, m => m.MapFrom(x => x.Image.ImageId));

            CreateMap<Discount, DiscountFullDto>();
        }
    }
}
