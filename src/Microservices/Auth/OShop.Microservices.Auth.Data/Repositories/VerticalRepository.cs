using MongoDB.Driver;
using OShop.Microservices.Auth.DataInterfaces;
using OShop.Microservices.Auth.Doman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OShop.Microservices.Auth.Data.Repositories
{
    public class VerticalRepository : IVerticalRepository
    {
        private readonly IMongoCollection<productDto> _item;
        private readonly IDatabaseFactory _databaseFactory;

        public VerticalRepository(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
            _item = _databaseFactory.GetDatabase().GetCollection<productDto>("Items");
        }

        public async Task<int> AddAsync(productDto productDto)
        {
            var result = await GetByIdAsync(productDto.productId);
            if (result != null)
            {
                await _item.ReplaceOneAsync(product => product.productId == productDto.productId, productDto);
                return 0;
            }
            else
            {
                Random rnd = new Random();
                productDto.productId = rnd.Next().ToString();
                await _item.InsertOneAsync(productDto);
                return 0;
            }
        }

        public async Task<bool> DeleteAsync(string productId)
        {
            var result = await GetByIdAsync(productId);
            if (result != null)
            {
                await _item.DeleteOneAsync(product => product.productId == productId);
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<productDto>> GetAllAsync()
        {
            return await _item.Find(product => true).ToListAsync();
        }

        public async Task<productDto> GetByIdAsync(string productId)
        {
            var filter = Builders<productDto>.Filter.Eq("_id", productId);
            var result = await _item.Find(filter).ToListAsync();
            return result.FirstOrDefault();
        }
    }
}
