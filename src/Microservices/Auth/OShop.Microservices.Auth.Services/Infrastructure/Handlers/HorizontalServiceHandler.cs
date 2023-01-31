using MongoDB.Bson;
using OShop.Microservices.Auth.DataInterfaces;
using OShop.Microservices.Auth.Model;
using OShop.Microservices.Auth.Services.Infrastructure.Builders.Interfaces;
using OShop.Microservices.Auth.Services.Infrastructure.Handlers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OShop.Microservices.Auth.Services.Infrastructure.Handlers
{
    public class HorizontalServiceHandler : IHorizontalServiceHandler
    {
        private readonly IHorizontalRepository _horizontalRepository;
        private readonly IHorizontalBuilder _horizontalBuilder;

        public HorizontalServiceHandler(IHorizontalRepository horizontalRepository, IHorizontalBuilder horizontalBuilder)
        {
            _horizontalRepository = horizontalRepository;
            _horizontalBuilder = horizontalBuilder;
        }

        public async Task<int> HandleAddAsync(productItem productItem)
        {
            var dto = _horizontalBuilder.Build(productItem);
            return await _horizontalRepository.AddAsync(dto);
        }

        public async Task<bool> HandleDeleteAsync(string productId)
        {
            return await _horizontalRepository.DeleteAsync(productId);
        }

        public async Task<List<productItem>> HandleGetAllAsync()
        {
            var dto = await _horizontalRepository.GetAllAsync();
            return dto.Select(x => _horizontalBuilder.Build(x)).ToList();
        }

        public async Task<productItem> HandleGetByIdAsync(string productId)
        {
            var dto = await _horizontalRepository.GetByIdAsync(productId);
            return _horizontalBuilder.Build(dto);
        }
    }
}
