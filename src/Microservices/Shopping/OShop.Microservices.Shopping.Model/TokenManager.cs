using IdentityModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OShop.Microservices.Shopping.Model
{
    public class TokenManager
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public TokenManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        private ClaimsPrincipal User => _httpContextAccessor.HttpContext.User;
        private IEnumerable<Claim> Claims => User.Claims;
        public string userId { get => GetUserId(); }

        public string role { get => GetRole(); }

        public string GetUserId()
        {
            if (User.HasClaim(claim => claim.Type == JwtClaimTypes.Id))
            {
                return (Claims.FirstOrDefault(claim => claim.Type == JwtClaimTypes.Id).Value).ToString();
            }
            return "";
        }

        public string GetRole()
        {
            if (User.HasClaim(claim => claim.Type == JwtClaimTypes.Role))
            {
                return (Claims.FirstOrDefault(claim => claim.Type == JwtClaimTypes.Role).Value).ToString();
            }
            return "";
        }
    }
}
