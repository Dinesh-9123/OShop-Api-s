using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OShop.Microservices.Auth.Api.Infrastructure.Handlers.Interfaces;
using OShop.Microservices.Auth.Api.Models.Response;
using OShop.Microservices.Auth.Model;

namespace OShop.Microservices.Auth.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VerticalController : ControllerBase
    {
        private readonly IVerticalHandler _verticalHandler;

        public VerticalController(IVerticalHandler verticalHandler)
        {
            _verticalHandler = verticalHandler;
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<ResponseWrapper<List<productItem>>> GetAll()
        {
            var response = new ResponseWrapper<List<productItem>>();
            try
            {
                response.Set(await _verticalHandler.HandleGetAllAsync());
            }
            catch (Exception ex)
            {
                response.Set(ex);
            }
            return response;
        }

        [HttpPost]
        [Route("post")]
        public async Task<ResponseWrapper<int>> Add(productItem productItem)
        {
            var response = new ResponseWrapper<int>();
            try
            {
                response.Set(await _verticalHandler.HandleAddAsync(productItem));
            }
            catch (Exception ex)
            {
                response.Set(ex);
            }
            return response;
        }

        [HttpGet]
        [Route("get-by-id")]
        public async Task<ResponseWrapper<productItem>> GeyById(string productId)
        {
            var response = new ResponseWrapper<productItem>();
            try
            {
                response.Set(await _verticalHandler.HandleGetByIdAsync(productId));
            }
            catch (Exception ex)
            {
                response.Set(ex);
            }
            return response;
        }

        [HttpDelete]
        [Route("remove")]
        public async Task<ResponseWrapper<bool>> Remove(string productId)
        {
            var response = new ResponseWrapper<bool>();
            try
            {
                response.Set(await _verticalHandler.HandleDeleteAsync(productId));
            }
            catch (Exception ex)
            {
                response.Set(ex);
            }
            return response;
        }
    }
}
