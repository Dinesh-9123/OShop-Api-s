using OShop.Microservices.Auth.DataInterfaces;
using OShop.Microservices.Auth.Model;
using OShop.Microservices.Auth.Services.Infrastructure.Builders;
using OShop.Microservices.Auth.Services.Infrastructure.Builders.Interfaces;
using OShop.Microservices.Auth.Services.Infrastructure.Handlers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OShop.Microservices.Auth.Services.Infrastructure.Handlers
{
    public class VerticalServiceHandler : IVerticalServiceHandler
    {
        private readonly IVerticalBuilder _verticalBuilder;
        private readonly IVerticalRepository _verticalRepository;
        public VerticalServiceHandler(IVerticalRepository verticalRepository, IVerticalBuilder verticalBuilder)
        {
            _verticalBuilder = verticalBuilder;
            _verticalRepository = verticalRepository;
        }
        public async Task<int> HandleAddAsync(productItem productItem)
        {
            var dto = _verticalBuilder.Build(productItem);
            return await _verticalRepository.AddAsync(dto);
        }

        public async Task<bool> HandleDeleteAsync(string productId)
        {
            return await _verticalRepository.DeleteAsync(productId);
        }

        public async Task<List<productItem>> HandleGetAllAsync()
        {
            var dto = await _verticalRepository.GetAllAsync();
            return dto.Select(x => _verticalBuilder.Build(x)).ToList();
        }

        public async Task<productItem> HandleGetByIdAsync(string productId)
        {
            var dto = await _verticalRepository.GetByIdAsync(productId);
            return _verticalBuilder.Build(dto);
        }
    }
}
