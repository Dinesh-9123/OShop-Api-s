using OShop.Microservices.Auth.Api.Infrastructure.Handlers.Interfaces;
using OShop.Microservices.Auth.Model;
using OShop.Microservices.Auth.ServiceInterfaces;

namespace OShop.Microservices.Auth.Api.Infrastructure.Handlers
{
    public class SignUpHandler : ISignUpHandler
    {
        private readonly ISignUpService _signUpService;
        public SignUpHandler(ISignUpService signUpService)
        {
            _signUpService = signUpService;
        }
        public async Task<SignUpResponseItem> HandleSignUpAsync(SignUpItem signUpItem)
        {
            return await _signUpService.SignUpAsync(signUpItem);    
        }
    }
}
