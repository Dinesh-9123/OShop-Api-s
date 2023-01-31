using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OShop.Microservices.Auth.Doman
{
    [BsonIgnoreExtraElements]
    public class productDto
    {
        [BsonId]
        [BsonElement("_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string productId { get; set; }
        public string name { get; set; }
        public int rating { get; set; }
        public int price { get; set; }
        public List<string> size { get; set; }
        public List<string> description { get; set; }
        public List<string> images { get; set; }
    }
}