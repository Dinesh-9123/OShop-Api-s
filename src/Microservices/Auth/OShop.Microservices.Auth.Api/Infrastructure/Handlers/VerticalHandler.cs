using OShop.Microservices.Auth.Api.Infrastructure.Handlers.Interfaces;
using OShop.Microservices.Auth.Model;
using OShop.Microservices.Auth.ServiceInterfaces;

namespace OShop.Microservices.Auth.Api.Infrastructure.Handlers
{
    public class VerticalHandler : IVerticalHandler
    {
        private readonly IVerticalService _verticalService;
        public VerticalHandler(IVerticalService verticalService)
        {
            _verticalService = verticalService;
        }

        public async Task<int> HandleAddAsync(productItem productItem)
        {
            return await _verticalService.AddAsync(productItem);
        }

        public async Task<bool> HandleDeleteAsync(string productId)
        {
            return await _verticalService.DeleteAsync(productId);
        }

        public async Task<List<productItem>> HandleGetAllAsync()
        {
            return await _verticalService.GetAllAsync();    
        }

        public async Task<productItem> HandleGetByIdAsync(string productId)
        {
            return await _verticalService.GetByIdAsync(productId);  
        }
    }
}
