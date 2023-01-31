using OShop.Microservices.Auth.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OShop.Microservices.Auth.Services.Infrastructure.Handlers.Interfaces
{
    public interface IHorizontalServiceHandler
    {
        Task<int> HandleAddAsync(productItem productItem);
        Task<List<productItem>> HandleGetAllAsync();
        Task<productItem> HandleGetByIdAsync(string productId);
        Task<bool> HandleDeleteAsync(string productId);
    }
}
