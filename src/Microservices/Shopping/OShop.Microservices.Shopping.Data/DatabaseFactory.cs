using MongoDB.Driver;
using OShop.Microservices.Shopping.DataInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OShop.Microservices.Shopping.Data
{
    public class DatabaseFactory : IDatabaseFactory
    {
        private readonly string _connectionString = "mongodb+srv://dineshchoudhary:Jatdinesh%40123@oshops.6j1vf7v.mongodb.net/?retryWrites=true&w=majority";

        private MongoClient Get()
        {
            return new MongoClient(_connectionString);
        }

        public dynamic GetDatabase()
        {
            MongoClient client = Get();
            var db = client.GetDatabase("MyShops");
            return db;
        }
    }
}
