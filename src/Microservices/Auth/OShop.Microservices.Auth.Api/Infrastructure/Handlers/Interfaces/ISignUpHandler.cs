using OShop.Microservices.Auth.Model;

namespace OShop.Microservices.Auth.Api.Infrastructure.Handlers.Interfaces
{
    public interface ISignUpHandler
    {
        Task<SignUpResponseItem> HandleSignUpAsync(SignUpItem signUpItem);
    }
}
