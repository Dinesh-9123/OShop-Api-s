using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OShop.Microservices.Auth.Model
{
    public class SignUpItem
    {
        public string email { get; set; }
        public string password { get; set; }
        public string mobileNo { get; set; }
    }
}
