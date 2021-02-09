using App1.Application.Common;
using App1.Domain.Entities;
using AutoMapper;

namespace App1.Application.Products.Queries
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<Product, ProductDto>();

            CreateMap<ProductIntAttribute, ProductIntAttributeDto>();
            CreateMap<ProductBoolAttribute, ProductBoolAttributeDto>();
            CreateMap<ProductStringAttribute, ProductStringAttributeDto>();
            CreateMap<ProductEnumAttribute, ProductEnumAttributeDto>()
                .ForMember(c => c.Value, m=> m.MapFrom(d => d.Value.Name));

            CreateMap<ProductVariant, ProductVariantDto>();

            CreateMap<ProductImage, ImageDto>()
                .ForMember(m => m.ImageId, m => m.MapFrom(x => x.Image.ImageId));
        }
    }
}
