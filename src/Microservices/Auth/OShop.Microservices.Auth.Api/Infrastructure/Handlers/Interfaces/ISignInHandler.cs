using OShop.Microservices.Auth.Model;

namespace OShop.Microservices.Auth.Api.Infrastructure.Handlers.Interfaces
{
    public interface ISignInHandler
    {
        Task<loginResponseItem> HandleSignInAsync(SignInItem signInItem);
    }
}
