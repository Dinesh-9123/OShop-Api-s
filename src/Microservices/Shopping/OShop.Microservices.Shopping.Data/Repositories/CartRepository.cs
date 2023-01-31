using MongoDB.Bson;
using MongoDB.Driver;
using OShop.Microservices.Shopping.DataInterfaces;
using OShop.Microservices.Shopping.Doman;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OShop.Microservices.Shopping.Data.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly IMongoCollection<CartDto> _cart;
        private readonly IDatabaseFactory _databaseFactory;
        public CartRepository(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
            _cart = _databaseFactory.GetDatabase().GetCollection<CartDto>("Carts");
        }

        public async Task<bool> AddToCartAsync(CartDto dto)
        {
            var result = await GetByIdAsync(dto.cartId);
            if (result != null)
            {
                await _cart.ReplaceOneAsync(cart => cart.cartId == dto.cartId, dto);
                return true;
            }
            else
            {
                await _cart.InsertOneAsync(dto);
                return true;
            }
        }

        public async Task<List<CartDto>> GetAllAsync(string userId)
        {
            var filter = Builders<CartDto>.Filter.Eq("userId", userId);
            var result = await _cart.Find(filter).ToListAsync();
            return result;
        }

        public async Task<CartDto> GetByIdAsync(string cartId)
        {
            var filter = Builders<CartDto>.Filter.Eq("_id", cartId);
            var result = await _cart.Find(filter).ToListAsync();
            return result.FirstOrDefault();
        }
        public async Task<bool> DeleteAsync(string cartId)
        {
            var filter = Builders<CartDto>.Filter.Eq("_id", cartId);
            var result = await _cart.DeleteOneAsync(filter);
            return true;
        }

        public async Task<bool> UpdateCart(CartDto cart)
        {
            var filter = Builders<CartDto>.Filter.Eq("_id", cart.cartId);
            await _cart.ReplaceOneAsync(filter,cart);
            return true;
        }

        public async Task<bool> GetByUserIdAndProductId(string userId, string productId)
        {
            var filter = Builders<CartDto>.Filter.Eq("userId", userId);
            filter &= Builders<CartDto>.Filter.Eq("productId", productId);
            var result = await _cart.Find(filter).ToListAsync();
            if(result != null && result.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
