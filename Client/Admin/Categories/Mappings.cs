using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App1.Client.Admin.Categories
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<Category, CategoryViewModel>();
            CreateMap<CategoryViewModel, CreateCategory>();
            CreateMap<CategoryViewModel, UpdateCategory>();
        }
    }
}
