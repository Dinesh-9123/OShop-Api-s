using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OShop.Microservices.Events.Doman
{
    public class ImageTemplateDto
    {
        public string imageTemplateId { get; set; }
        public string gameId { get; set; }
        public string templateName { get; set; }
        public string templateUrl { get; set; }
    }
}
