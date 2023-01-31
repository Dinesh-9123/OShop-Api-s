using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OShop.Microservices.Shopping.Api.Infrastructure.Handlers.Interfaces;
using OShop.Microservices.Shopping.Api.Models.Response;
using OShop.Microservices.Shopping.Model;

namespace OShop.Microservices.Shopping.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CartController : ControllerBase
    {
        private readonly ICartHandler _cartHandler;
        public CartController(ICartHandler cartHandler)
        {
            _cartHandler = cartHandler;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ResponseWrapper<CartResponseItem>> GetCartItems()
        {
            var response = new ResponseWrapper<CartResponseItem>();
            try
            {
                response.Set(await _cartHandler.HandleGetAllAsync());
            }
            catch (Exception ex)
            {
                response.Set(ex);
            }
            return response;
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<ResponseWrapper<CartItem>> GetById(string cartId)
        {
            var response = new ResponseWrapper<CartItem>();
            try
            {
                response.Set(await _cartHandler.HandleGetByIdAsync(cartId));
            }
            catch (Exception ex)
            {
                response.Set(ex);
            }
            return response;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<ResponseWrapper<bool>> Post(ProductItem cartItem)
        {
            var response = new ResponseWrapper<bool>();
            try
            {
                response.Set(await _cartHandler.HandleAddAsync(cartItem));
            }
            catch (Exception ex)
            {
                response.Set(ex);
            }
            return response;
        }

        [HttpPost]
        [Route("increment")]
        public async Task<ResponseWrapper<bool>> Increment(string cartId)
        {
            var response = new ResponseWrapper<bool>();
            try
            {
                response.Set(await _cartHandler.HandleIncrementAsync(cartId));
            }
            catch (Exception ex)
            {
                response.Set(ex);
            }
            return response;
        }
        
        [HttpPost]
        [Route("decrement")]
        public async Task<ResponseWrapper<bool>> Decrement(string cartId)
        {
            var response = new ResponseWrapper<bool>();
            try
            {
                response.Set(await _cartHandler.HandleDecrementAsync(cartId));
            }
            catch (Exception ex)
            {
                response.Set(ex);
            }
            return response;
        }
    }
}
