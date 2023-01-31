using OShop.Microservices.Shopping.Model;
using OShop.Microservices.Shopping.ServiceInterfaces;
using OShop.Microservices.Shopping.Services.Infrastructure.Handlers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OShop.Microservices.Shopping.Services
{
    public class CartService : ICartService
    {
        private readonly ICartServiceHandler _cartServiceHandler;
        public CartService(ICartServiceHandler cartServiceHandler)
        {
            _cartServiceHandler = cartServiceHandler;
        }

        public async Task<bool> AddAsync(ProductItem cartItem)
        {
            return await _cartServiceHandler.HandleAddAsync(cartItem);
        }

        public async Task<bool> DecrementAsync(string cartId)
        {
            return await _cartServiceHandler.HandleDecrement(cartId);
        }

        public async Task<CartResponseItem> GetAllAsync()
        {
            return await _cartServiceHandler.HandleGetAllAsync();
        }

        public async Task<CartItem> GetByIdAsync(string cartId)
        {
            return await _cartServiceHandler.HandleGetByIdAsync(cartId);
        }

        public async Task<bool> IncrementAsync(string cartId)
        {
            return await _cartServiceHandler.HandleIncrement(cartId);
        }
    }
}
