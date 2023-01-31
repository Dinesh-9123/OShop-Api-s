using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OShop.Microservices.Auth.Doman
{
    public class SignInDto
    {
        [BsonId]
        public string userId { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string mobileNo { get; set; }
        public string status { get; set; }
        public string role { get; set; }
    }
}
