using OShop.Microservices.Auth.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OShop.Microservices.Auth.Services.Infrastructure.Handlers.Interfaces
{
    public interface ISingInServiceHandler
    {
        Task<loginResponseItem> HandleSignInAsync(SignInItem signInItem);
    }
}
