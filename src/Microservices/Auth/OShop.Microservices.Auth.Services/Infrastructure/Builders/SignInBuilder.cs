using AutoMapper;
using OShop.Microservices.Auth.Doman;
using OShop.Microservices.Auth.Model;
using OShop.Microservices.Auth.Services.Infrastructure.Builders.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OShop.Microservices.Auth.Services.Infrastructure.Builders
{
    public class SignInBuilder : ISignInBuilder
    {
        private readonly IMapper _mapper;
        public SignInBuilder(IMapper mapper)
        {
            _mapper = mapper;
        }
        public SignInItem Build(SignInDto signInDto)
        {
            return _mapper.Map<SignInItem>(signInDto);
        }

        public SignInDto Build(SignInItem signInItem)
        {
            return _mapper.Map<SignInDto>(signInItem);
        }
    }
}
