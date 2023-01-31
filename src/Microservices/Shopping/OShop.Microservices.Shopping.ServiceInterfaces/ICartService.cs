using OShop.Microservices.Shopping.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OShop.Microservices.Shopping.ServiceInterfaces
{
    public interface ICartService
    {
        Task<CartResponseItem> GetAllAsync();
        Task<CartItem> GetByIdAsync(string cartId);
        Task<bool> AddAsync(ProductItem cartItem);
        Task<bool> IncrementAsync(string cartId);
        Task<bool> DecrementAsync(string cartId);

    }
}
