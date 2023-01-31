using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OShop.Microservices.Shopping.DataInterfaces
{
    public interface IDatabaseFactory
    {
        dynamic GetDatabase();
    }
}
