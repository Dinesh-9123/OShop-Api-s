using AutoMapper;
using OShop.Microservices.Auth.Doman;
using OShop.Microservices.Auth.Model;
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
            CreateMap<SignInItem, SignInDto>();
            CreateMap<SignUpItem , SignUpDto>();
            CreateMap<SignUpResponseItem, SignUpResponseDto>();
            CreateMap<productItem, productDto>();
        }
    }
}
