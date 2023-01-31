using OShop.Microservices.Auth.Api.Infrastructure.Handlers.Interfaces;
using OShop.Microservices.Auth.Model;
using OShop.Microservices.Auth.ServiceInterfaces;

namespace OShop.Microservices.Auth.Api.Infrastructure.Handlers
{
    public class SignInHandler : ISignInHandler
    {
        private readonly ISignInService _signInService;
        public SignInHandler(ISignInService signInService)
        {
            _signInService = signInService;
        }

        public async Task<loginResponseItem> HandleSignInAsync(SignInItem signInItem)
        {
            return await _signInService.SignInAsync(signInItem);  
        }
    }
}
