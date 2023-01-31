using OShop.Microservices.Auth.Doman;
using OShop.Microservices.Auth.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OShop.Microservices.Auth.Services.Infrastructure.Builders.Interfaces
{
    public interface ISignInBuilder
    {
        SignInItem Build(SignInDto signInDto);
        SignInDto Build(SignInItem signInItem);
    }
}
