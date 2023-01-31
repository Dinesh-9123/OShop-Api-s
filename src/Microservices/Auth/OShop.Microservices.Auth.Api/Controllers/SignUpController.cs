using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OShop.Microservices.Auth.Api.Infrastructure.Handlers.Interfaces;
using OShop.Microservices.Auth.Api.Models.Response;
using OShop.Microservices.Auth.Model;

namespace OShop.Microservices.Auth.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignUpController : ControllerBase
    {
        private readonly ISignUpHandler _signUpHandler;
        public SignUpController(ISignUpHandler signUpHandler)
        {
            _signUpHandler = signUpHandler;
        }

        [HttpPost]
        [Route("signUp")]
        public async Task<ResponseWrapper<SignUpResponseItem>> SignUp(SignUpItem signUpItem)
        {
            var response = new ResponseWrapper<SignUpResponseItem>();
            try
            {
                response.Set(await _signUpHandler.HandleSignUpAsync(signUpItem));
            }
            catch (Exception ex)
            {
                response.Set(ex);
            }

            return response;
        }
    }
}
