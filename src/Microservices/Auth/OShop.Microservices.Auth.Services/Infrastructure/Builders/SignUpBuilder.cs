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
    public class SignUpBuilder : ISignUpBuilder
    {
        private readonly IMapper _mapper;
        public SignUpBuilder(IMapper mapper)
        {
            _mapper = mapper;
        }
        public SignUpItem Build(SignUpDto signUpDto)
        {
            return _mapper.Map<SignUpItem>(signUpDto);
        }

        public SignUpDto Build(SignUpItem signUpItem)
        {
            return _mapper.Map<SignUpDto>(signUpItem);
        }

        public SignUpResponseDto Build(SignUpResponseItem signUpResponseItem)
        {
            return _mapper.Map<SignUpResponseDto>(signUpResponseItem);
        }

        public SignUpResponseItem Build(SignUpResponseDto signUpResponseDto)
        {
            return _mapper.Map<SignUpResponseItem>(signUpResponseDto);
        }
    }
}
