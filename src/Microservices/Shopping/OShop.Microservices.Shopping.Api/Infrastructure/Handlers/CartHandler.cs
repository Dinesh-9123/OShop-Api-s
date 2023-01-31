using OShop.Microservices.Shopping.Api.Infrastructure.Handlers.Interfaces;
using OShop.Microservices.Shopping.Model;
using OShop.Microservices.Shopping.ServiceInterfaces;

namespace OShop.Microservices.Shopping.Api.Infrastructure.Handlers
{
    public class CartHandler : ICartHandler
    {
        private readonly ICartService _cartService;
        public CartHandler(ICartService cartService)
        {
            _cartService = cartService;
        }

        public async Task<bool> HandleAddAsync(ProductItem cartItem)
        {
            return await _cartService.AddAsync(cartItem);   
        }

        public async Task<bool> HandleDecrementAsync(string cartId)
        {
            return await _cartService.DecrementAsync(cartId);
        }

        public async Task<CartResponseItem> HandleGetAllAsync()
        {
            return await _cartService.GetAllAsync();
        }

        public async Task<CartItem> HandleGetByIdAsync(string cartId)
        {
            return await _cartService.GetByIdAsync(cartId);
        }

        public async Task<bool> HandleIncrementAsync(string cartId)
        {
            return await _cartService.IncrementAsync(cartId);
        }
    }
}
