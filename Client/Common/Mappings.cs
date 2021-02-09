using System;
using AutoMapper;

namespace App1.Client.Common
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<Address, Client.Address>();
        }
    }
}
