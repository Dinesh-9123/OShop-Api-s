using OShop.Microservices.Auth.Model;
using OShop.Microservices.Auth.ServiceInterfaces;
using OShop.Microservices.Auth.Services.Infrastructure.Handlers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OShop.Microservices.Auth.Services
{
    public class SignInService : ISignInService
    {
        private readonly ISingInServiceHandler _singInServiceHandler;

        public SignInService(ISingInServiceHandler singInServiceHandler)
        {
            _singInServiceHandler = singInServiceHandler;
        }

        public async Task<loginResponseItem> SignInAsync(SignInItem signInItem)
        {
            return await _singInServiceHandler.HandleSignInAsync(signInItem);
        }
    }
}
