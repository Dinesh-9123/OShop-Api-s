using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OShop.Microservices.Events.Doman
{
    public class AddGameRuleDto
    {
        public string ruleId { get; set; }
        public string addGameDataId { get; set; }
        public List<string> rules { get; set; }
    }
}
