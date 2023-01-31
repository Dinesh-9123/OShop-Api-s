using OShop.Microservices.Shopping.Doman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OShop.Microservices.Shopping.DataInterfaces
{
    public interface ICartRepository
    {
        Task<bool> AddToCartAsync(CartDto dto);
        Task<List<CartDto>> GetAllAsync(string userId);
        Task<CartDto> GetByIdAsync(string cartId);
        Task<bool> UpdateCart(CartDto cart);
        Task<bool> DeleteAsync(string cartId);
        Task<bool> GetByUserIdAndProductId(string userId, string productId);
    }
}
