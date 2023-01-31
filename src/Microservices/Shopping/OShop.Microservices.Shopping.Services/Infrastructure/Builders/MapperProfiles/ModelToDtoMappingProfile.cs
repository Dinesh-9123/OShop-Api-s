using AutoMapper;
using OShop.Microservices.Shopping.Doman;
using OShop.Microservices.Shopping.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OShop.Microservices.Auth.Services.Infrastructure.Builders.MapperProfiles
{
    public class ModelToDtoMappingProfile : Profile
    {
        public ModelToDtoMappingProfile()
        {
            CreateMap<CartItem, CartDto>();
            CreateMap<ProductItem, CartDto>();
        }
    }
}
