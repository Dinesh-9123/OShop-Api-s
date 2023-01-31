using OShop.Microservices.Auth.Api.Infrastructure.Handlers.Interfaces;
using OShop.Microservices.Auth.Model;
using OShop.Microservices.Auth.ServiceInterfaces;

namespace OShop.Microservices.Auth.Api.Infrastructure.Handlers
{
    public class HorizontalHandler : IHorizontalHandler
    {
        private readonly IHorizontalService _horizontalService;
        public HorizontalHandler(IHorizontalService horizontalService)
        {
            _horizontalService = horizontalService;
        }
        public async Task<int> HandleAddAsync(productItem productItem)
        {
            return await _horizontalService.AddAsync(productItem);
        }

        public async Task<bool> HandleDeleteAsync(string productId)
        {
            return await _horizontalService.DeleteAsync(productId);
        }

        public async Task<List<productItem>> HandleGetAllAsync()
        {
            return await _horizontalService.GetAllAsync();
        }

        public async Task<productItem> HandleGetByIdAsync(string productId)
        {
            return await _horizontalService.GetByIdAsync(productId);
        }
    }
}
