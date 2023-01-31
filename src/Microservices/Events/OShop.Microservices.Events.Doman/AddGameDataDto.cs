using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OShop.Microservices.Events.Doman
{
    public class AddGameDataDto
    {
        public string addGameDataId { get; set; }
        public string name { get; set; }
        public string venue { get; set; }
        public DateTime startDate { set; get; }
        public DateTime endDate { set; get; }
        public int entryFee { get; set; }
        public string email { get; set; }
        public string mobileNo { get; set; }
        public int winnerPrice { get; set; }
        public string description { get; set; }
    }
}
