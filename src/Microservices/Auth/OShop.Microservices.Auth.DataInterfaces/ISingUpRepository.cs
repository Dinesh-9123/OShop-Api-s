using OShop.Microservices.Auth.Doman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OShop.Microservices.Auth.DataInterfaces
{
    public interface ISingUpRepository
    {
        Task<SignUpResponseDto> SignUpAsync(SignUpDto signUpDto);
        Task<SignUpResponseDto> GetByEmailAsync(string email);
        Task<SignUpResponseDto> GetByPhoneNumberAsync(string phoneNumber);
    }
}
