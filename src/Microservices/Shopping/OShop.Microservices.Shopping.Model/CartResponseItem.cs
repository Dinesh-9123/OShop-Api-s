using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OShop.Microservices.Shopping.Model
{
    public class CartResponseItem
    {
        public int totalPrice { get; set; }
        public List<CartItem> items { get; set; }
    }
}
