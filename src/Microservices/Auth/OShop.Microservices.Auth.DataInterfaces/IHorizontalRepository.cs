using OShop.Microservices.Auth.Doman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OShop.Microservices.Auth.DataInterfaces
{
    public interface IHorizontalRepository
    {
        Task<List<productDto>> GetAllAsync();
        Task<productDto> GetByIdAsync(string productId);
        Task<int> AddAsync(productDto productDto);
        Task<bool> DeleteAsync(string productId);
    }
}
