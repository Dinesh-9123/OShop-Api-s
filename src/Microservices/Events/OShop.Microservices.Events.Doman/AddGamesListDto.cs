using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OShop.Microservices.Events.Doman
{
    public class AddGamesListDto
    {
        public string gameId { get; set; }
        public string gameName { get; set; }
        public string gameUrl { get; set; }
    }
}
