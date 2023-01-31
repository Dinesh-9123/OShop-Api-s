using OShop.Microservices.Auth.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OShop.Microservices.Auth.ServiceInterfaces
{
    public interface IVerticalService
    {
        Task<int> AddAsync(productItem productItem);
        Task<List<productItem>> GetAllAsync();
        Task<productItem> GetByIdAsync(string productId);
        Task<bool> DeleteAsync(string productId);
    }
}
