using OShop.Microservices.Auth.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OShop.Microservices.Auth.ServiceInterfaces
{
    public interface ISignUpService
    {
        Task<SignUpResponseItem> SignUpAsync(SignUpItem signUpItem);
    }
}
