using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OShop.Microservices.Auth.Model
{
    public class loginResponseItem
    {
        public string token { get; set; }
        public int expiresIn { get; set; }
    }
}
