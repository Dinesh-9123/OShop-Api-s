using AutoMapper;
using OShop.Microservices.Shopping.Doman;
using OShop.Microservices.Shopping.Model;
using OShop.Microservices.Shopping.Services.Infrastructure.Builders.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OShop.Microservices.Shopping.Services.Infrastructure.Builders
{
    public class CartBuilder : ICartBuilder
    {
        private readonly IMapper _mapper;
        public CartBuilder(IMapper mapper)
        {
            _mapper = mapper;
        }

        public CartDto Build(CartItem cartItem)
        {
            return _mapper.Map<CartDto>(cartItem);
        }

        public CartItem Build(CartDto cartItem)
        {
            return _mapper.Map<CartItem>(cartItem);
        }

        public CartDto Build(ProductItem productItem)
        {
            return _mapper.Map<CartDto>(productItem);
        }
    }
}
