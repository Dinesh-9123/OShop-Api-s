using OShop.Microservices.Auth.Doman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OShop.Microservices.Auth.DataInterfaces
{
    public interface ISingInRepository
    {
        Task<SignInDto> SignInAsync(SignInDto signInDto);
    }
}
