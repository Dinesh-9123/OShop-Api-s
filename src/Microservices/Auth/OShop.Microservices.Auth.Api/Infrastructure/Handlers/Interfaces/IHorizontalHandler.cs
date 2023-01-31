using OShop.Microservices.Auth.Model;

namespace OShop.Microservices.Auth.Api.Infrastructure.Handlers.Interfaces
{
    public interface IHorizontalHandler
    {
        Task<int> HandleAddAsync(productItem productItem);
        Task<List<productItem>> HandleGetAllAsync();
        Task<productItem> HandleGetByIdAsync(string productId);
        Task<bool> HandleDeleteAsync(string productId);
    }
}
