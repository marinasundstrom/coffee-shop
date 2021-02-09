using App1.Application.Categories.Commands.CreateCategory;
using App1.Application.Categories.Commands.UpdateCategory;
using App1.Domain.Entities;
using AutoMapper;

namespace App1.Application.Categories.Commands
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<CreateCategoryCommand, ProductCategory>();
            CreateMap<UpdateCategoryCommand, ProductCategory>();
        }
    }
}
