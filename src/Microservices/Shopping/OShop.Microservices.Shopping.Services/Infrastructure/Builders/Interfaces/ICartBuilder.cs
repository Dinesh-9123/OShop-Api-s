using OShop.Microservices.Shopping.Doman;
using OShop.Microservices.Shopping.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OShop.Microservices.Shopping.Services.Infrastructure.Builders.Interfaces
{
    public interface ICartBuilder
    {
        CartDto Build(CartItem cartItem);
        CartItem Build(CartDto cartItem);
        CartDto Build(ProductItem productItem);
    }
}
