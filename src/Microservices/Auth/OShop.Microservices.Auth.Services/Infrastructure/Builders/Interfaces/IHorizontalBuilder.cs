using OShop.Microservices.Auth.Doman;
using OShop.Microservices.Auth.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OShop.Microservices.Auth.Services.Infrastructure.Builders.Interfaces
{
    public interface IHorizontalBuilder
    {
        productDto Build(productItem productItem);
        productItem Build(productDto productDto);
    }
}
