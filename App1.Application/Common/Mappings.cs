using App1.Domain.Entities;
using AutoMapper;

namespace App1.Application.Common
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<Campaign, CampaignShortDto>();

            CreateMap<Product, ProductShortDto>();
            CreateMap<ProductVariant, ProductVariantShortDto>();

            CreateMap<ProductCategory, CategoryShortDto>();
            CreateMap<Discount, DiscountShortDto>();

            CreateMap<Person, PersonShortDto>();
            CreateMap<Contact, ContactShortDto>();

            CreateMap<Source, SourceShortDto>();

            CreateMap<Address, AddressDto>();
            CreateMap<Address2, AddressDto>();

            CreateMap<Image, ImageDto>();

            CreateMap<AddressDto, Address>();
        }
    }
}
