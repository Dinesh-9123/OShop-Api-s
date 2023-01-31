using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OShop.Microservices.Auth.Api.Infrastructure.Handlers.Interfaces;
using OShop.Microservices.Auth.Api.Models.Response;
using OShop.Microservices.Auth.Model;

namespace OShop.Microservices.Auth.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignInController : ControllerBase
    {
        private readonly ISignInHandler _signInHandler;
        public SignInController(ISignInHandler signInHandler)
        {
            _signInHandler = signInHandler;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ResponseWrapper<loginResponseItem>> SignIn(SignInItem signInItem)
        {
            var response = new ResponseWrapper<loginResponseItem>();
            try
            {
                response.Set(await _signInHandler.HandleSignInAsync(signInItem));
            }
            catch (Exception ex)
            {
                response.Set(ex);
            }
            return response;
        }
    }
}
