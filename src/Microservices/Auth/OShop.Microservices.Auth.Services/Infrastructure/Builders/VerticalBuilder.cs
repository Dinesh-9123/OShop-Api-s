using AutoMapper;
using OShop.Microservices.Auth.Doman;
using OShop.Microservices.Auth.Model;
using OShop.Microservices.Auth.Services.Infrastructure.Builders.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OShop.Microservices.Auth.Services.Infrastructure.Builders
{
    public class VerticalBuilder : IVerticalBuilder
    {
        private readonly IMapper _mapper;
        public VerticalBuilder(IMapper mapper)
        {
            _mapper = mapper;
        }

        public productDto Build(productItem productItem)
        {
            return _mapper.Map<productDto>(productItem);
        }

        public productItem Build(productDto productDto)
        {
            return _mapper.Map<productItem>(productDto);
        }
    }
}
