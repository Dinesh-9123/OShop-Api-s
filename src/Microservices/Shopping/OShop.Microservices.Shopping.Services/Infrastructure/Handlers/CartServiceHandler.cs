using MongoDB.Bson;
using OShop.Microservices.Shopping.DataInterfaces;
using OShop.Microservices.Shopping.Model;
using OShop.Microservices.Shopping.Services.Infrastructure.Builders.Interfaces;
using OShop.Microservices.Shopping.Services.Infrastructure.Handlers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OShop.Microservices.Shopping.Services.Infrastructure.Handlers
{
    public class CartServiceHandler : ICartServiceHandler
    {
        private readonly ICartBuilder _cartBuilder;
        private readonly ICartRepository _cartRepository;
        private readonly TokenManager _tokenManager;
        public CartServiceHandler(ICartBuilder cartBuilder, ICartRepository cartRepository, TokenManager tokenManager)
        {
            _cartBuilder = cartBuilder;
            _cartRepository = cartRepository;
            _tokenManager = tokenManager;
        }

        public async Task<bool> HandleAddAsync(ProductItem cartItem)
        {
            var result = await _cartRepository.GetByUserIdAndProductId(_tokenManager.userId, cartItem.productId);
            if (result)
            {
                return false;
            }
            else
            { 
                var dto = _cartBuilder.Build(cartItem);
                dto.userId = _tokenManager.userId;
                dto.quantity = 1;
                dto.cartId = ObjectId.GenerateNewId().ToString();
                return await _cartRepository.AddToCartAsync(dto);
            }
        }

        public async Task<bool> HandleDecrement(string cartId)
        {
            var dto = await _cartRepository.GetByIdAsync(cartId);
            if(dto == null)
            {
                return false;
            }
            else
            {
                if (dto.quantity == 1)
                {
                    return await _cartRepository.DeleteAsync(cartId);
                }
                else
                {
                    dto.quantity -= 1;
                    return await _cartRepository.UpdateCart(dto);
                }
            }
        }

        public async Task<CartResponseItem> HandleGetAllAsync()
        {
            var dto = await _cartRepository.GetAllAsync(_tokenManager.userId);
            var items = dto.Select(x => _cartBuilder.Build(x)).ToList();
            var total = 0;

            foreach (var item in items)
            {
                total += item.price * item.quantity;
            }
            var result = new CartResponseItem
            {
                items = items,
                totalPrice = total,
            };

            return result;
        }

        public async Task<CartItem> HandleGetByIdAsync(string cartId)
        {
            var dto = await _cartRepository.GetByIdAsync(cartId);
            return _cartBuilder.Build(dto);
        }

        public async Task<bool> HandleIncrement(string cartId)
        {
            var dto = await _cartRepository.GetByIdAsync(cartId);
            if(dto == null)
            {
                return false;
            }
            else
            {
                dto.quantity += 1;
                return await _cartRepository.UpdateCart(dto);
            }
        }
    }
}
