using OShop.Microservices.Auth.DataInterfaces;
using OShop.Microservices.Auth.Model;
using OShop.Microservices.Auth.Services.Authentication;
using OShop.Microservices.Auth.Services.Infrastructure.Builders.Interfaces;
using OShop.Microservices.Auth.Services.Infrastructure.Handlers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OShop.Microservices.Auth.Services.Infrastructure.Handlers
{
    public class SingInServiceHandler : ISingInServiceHandler
    {
        private readonly ISingInRepository _singInRepository;
        private readonly ISignInBuilder _signInBuilder;
        public SingInServiceHandler(ISingInRepository singInRepository, ISignInBuilder signInBuilder)
        {
            _singInRepository = singInRepository;
            _signInBuilder = signInBuilder;
        }
        public async Task<loginResponseItem> HandleSignInAsync(SignInItem signInItem)
        {
            var res = _signInBuilder.Build(signInItem);

            var result = await _singInRepository.SignInAsync(res);
            var token = TokenManager.GenerateToken(result.role, result.userId.ToString(), result.email, result.mobileNo);
            var response = new loginResponseItem
            {
                token = token,
                expiresIn = 120
            };
            return response;
        }
    }
}
