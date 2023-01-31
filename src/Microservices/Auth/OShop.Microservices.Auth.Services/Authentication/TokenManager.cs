using IdentityModel;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OShop.Microservices.Auth.Services.Authentication
{
    public class TokenManager
    {
        private static string ClientUrl = "http://localhost:4200/";
        private static string Issuer = "self";
        private static int ExpireTimeInMinutes = 120;

        public static string GenerateToken(string role, string userId, string email, string mobNo)
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes("401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1"));
            var claimsIdentity = new ClaimsIdentity(new List<Claim>()
            {
                new Claim(JwtClaimTypes.Id, Convert.ToString(userId)),
                new Claim(JwtClaimTypes.Role,Convert.ToString(role)),
                new Claim(JwtClaimTypes.GivenName,Convert.ToString(email)),
                new Claim(JwtClaimTypes.ClientId, Convert.ToString(mobNo)),
            }, "Custom");


            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                Audience = ClientUrl,
                Issuer = Issuer,
                Subject = claimsIdentity,
                Expires = DateTime.UtcNow.AddMinutes(ExpireTimeInMinutes),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
            };

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken token = handler.CreateJwtSecurityToken(descriptor);

            var res = handler.WriteToken(token);

            res = String.Join("bearer ", res);
            return res;
        }

    }
}
