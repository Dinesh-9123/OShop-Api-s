using OShop.Microservices.Shopping.Model;

namespace OShop.Microservices.Shopping.Api.Infrastructure.Handlers.Interfaces
{
    public interface ICartHandler
    {
        Task<CartResponseItem> HandleGetAllAsync();
        Task<CartItem> HandleGetByIdAsync(string cartId);
        Task<bool> HandleAddAsync(ProductItem cartItem);
        Task<bool> HandleIncrementAsync(string cartId);  
        Task<bool> HandleDecrementAsync(string cartId);  
    }
}
