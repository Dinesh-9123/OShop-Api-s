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
    public class VerticalService : IVerticalService
    {
        private readonly IVerticalServiceHandler _verticalServiceHandler;
        public VerticalService(IVerticalServiceHandler verticalServiceHandler)
        {
            _verticalServiceHandler = verticalServiceHandler;
        }

        public async Task<int> AddAsync(productItem productItem)
        {
            return await _verticalServiceHandler.HandleAddAsync(productItem);
        }

        public async Task<bool> DeleteAsync(string productId)
        {
            return await _verticalServiceHandler.HandleDeleteAsync(productId);
        }

        public async Task<List<productItem>> GetAllAsync()
        {
            return await _verticalServiceHandler.HandleGetAllAsync();
        }

        public async Task<productItem> GetByIdAsync(string productId)
        {
            return await _verticalServiceHandler.HandleGetByIdAsync(productId);
        }
    }
}
