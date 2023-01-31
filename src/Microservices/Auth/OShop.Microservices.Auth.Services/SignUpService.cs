using OShop.Microservices.Auth.Model;
using OShop.Microservices.Auth.ServiceInterfaces;
using OShop.Microservices.Auth.Services.Infrastructure.Handlers;
using OShop.Microservices.Auth.Services.Infrastructure.Handlers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OShop.Microservices.Auth.Services
{
    public class SignUpService : ISignUpService
    {
        private readonly ISingUpServiceHandler _singUpServiceHandler;

        public SignUpService(ISingUpServiceHandler singUpServiceHandler)
        {
            _singUpServiceHandler = singUpServiceHandler;
        }

        public async Task<SignUpResponseItem> SignUpAsync(SignUpItem signUpItem)
        {
            return await _singUpServiceHandler.HandleSignUpAsync(signUpItem);
        }
    }
}
