using OShop.Microservices.Auth.Model;
using OShop.Microservices.Auth.ServiceInterfaces;
using OShop.Microservices.Auth.Services.Infrastructure.Handlers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OShop.Microservices.Auth.Services
{
    public class HorizontalService : IHorizontalService
    {
        private readonly IHorizontalServiceHandler _horizontalServiceHandler;

        public HorizontalService(IHorizontalServiceHandler horizontalServiceHandler)
        {
            _horizontalServiceHandler = horizontalServiceHandler;
        }

        public async Task<int> AddAsync(productItem productItem)
        {
            return await _horizontalServiceHandler.HandleAddAsync(productItem);
        }

        public async Task<bool> DeleteAsync(string productId)
        {
            return await _horizontalServiceHandler.HandleDeleteAsync(productId);
        }

        public async Task<List<productItem>> GetAllAsync()
        {
            return await _horizontalServiceHandler.HandleGetAllAsync();
        }

        public async Task<productItem> GetByIdAsync(string productId)
        {
            return await _horizontalServiceHandler.HandleGetByIdAsync(productId);
        }
    }
}
