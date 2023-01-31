using MongoDB.Bson;
using MongoDB.Driver;
using OShop.Microservices.Auth.DataInterfaces;
using OShop.Microservices.Auth.Doman;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OShop.Microservices.Auth.Data.Repositories
{
    public class HorizontalRepository : IHorizontalRepository
    {
        private readonly IMongoCollection<productDto> _products;
        private readonly IDatabaseFactory _databaseFactory;
        public HorizontalRepository(IDatabaseFactory databaseFactory) 
        {
            _databaseFactory = databaseFactory;
            _products = _databaseFactory.GetDatabase().GetCollection<productDto>("Products");
        }

        public async Task<int> AddAsync(productDto productDto)
        {
            var result = await GetByIdAsync(productDto.productId);
            if(result != null)
            {
                await _products.ReplaceOneAsync(product => product.productId == productDto.productId, productDto);
                return 0;
            }
            else
            {
                productDto.productId = ObjectId.GenerateNewId().ToString();
                await _products.InsertOneAsync(productDto);
                return 0;
            }
        }

        public async Task<bool> DeleteAsync(string productId)
        {
            var result = await GetByIdAsync(productId);
            if(result != null)
            {
                await _products.DeleteOneAsync(product => product.productId == productId);
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<productDto>> GetAllAsync()
        {
            var result = await _products.Find(product => true).ToListAsync();
            return result;
        }

        public async Task<productDto> GetByIdAsync(string productId)
        {
            var filter = Builders<productDto>.Filter.Eq("_id", productId);
            var result = await _products.Find(filter).ToListAsync();
            return result.FirstOrDefault();
        }
    }
}
