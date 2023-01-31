using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OShop.Microservices.Auth.DataInterfaces
{
    public interface IDatabaseFactory
    {
        dynamic GetDatabase();
    }
}
