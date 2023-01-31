using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OShop.Microservices.Shopping.Doman
{
    public class ProductDto
    {
        [BsonId]
        public string cartId { get; set; }
        public string userId { get; set; }
        public string productId { get; set; }
        public string name { get; set; }
        public int rating { get; set; }
        public int price { get; set; }
        public List<string> size { get; set; }
        public List<string> description { get; set; }
        public List<string> images { get; set; }
    }
}
