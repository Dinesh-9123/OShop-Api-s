using OShop.Microservices.Shopping.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OShop.Microservices.Shopping.Services.Infrastructure.Handlers.Interfaces
{
    public interface ICartServiceHandler
    {
        Task<CartResponseItem> HandleGetAllAsync();
        Task<CartItem> HandleGetByIdAsync(string cartId);
        Task<bool> HandleAddAsync(ProductItem cartItem);
        Task<bool> HandleIncrement(string cartId);
        Task<bool> HandleDecrement(string cartId);

    }
}
