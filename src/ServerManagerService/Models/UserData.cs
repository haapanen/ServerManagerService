using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerManagerService.Models
{
    public class JWT
    {
        public string Issuer { get; set; }
        public DateTime IssuetAt { get; set; }
        public DateTime Expiration { get; set; }
        public string Audience { get; set; }
        public string Subject { get; set; }
    }
}
