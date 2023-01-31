using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OShop.Microservices.Auth.Doman
{
    public class SignUpResponseDto
    {
        public bool result { get; set; }
        public bool isEmail { get; set; }
        public bool isMobileNo { get; set; }
    }
}
