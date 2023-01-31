using OShop.Microservices.Auth.DataInterfaces;
using OShop.Microservices.Auth.Model;
using OShop.Microservices.Auth.Services.Infrastructure.Builders.Interfaces;
using OShop.Microservices.Auth.Services.Infrastructure.Handlers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OShop.Microservices.Auth.Services.Infrastructure.Handlers
{
    public class SingUpServiceHandler : ISingUpServiceHandler
    {
        private readonly ISignUpBuilder _signUpBuilder;
        private readonly ISingUpRepository _singUpRepository;

        public SingUpServiceHandler(ISignUpBuilder signUpBuilder, ISingUpRepository singUpRepository)
        {
            _signUpBuilder = signUpBuilder;
            _singUpRepository = singUpRepository;
        }

        public async Task<SignUpResponseItem> HandleSignUpAsync(SignUpItem signUpItem)
        {
            var dto = _signUpBuilder.Build(signUpItem);

            var emailCheack = await _singUpRepository.GetByEmailAsync(dto.email);
            if(emailCheack.isEmail == true) 
            {
                throw new Exception("email already exist");
            }
            else
            {
                var mobileNoCheack = await _singUpRepository.GetByPhoneNumberAsync(dto.mobileNo);
                if(mobileNoCheack.isMobileNo == true) 
                {
                    throw new Exception("mobile no is already exist");
                }
                else
                {
                    dto.status = "Active";
                    dto.role = "User";
                    var response = await _singUpRepository.SignUpAsync(dto);
                    var result = _signUpBuilder.Build(response);
                    return result;
                }
            }
        }
    }
}
