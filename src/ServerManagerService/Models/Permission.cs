using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerManagerService.Models
{
    public class Permission
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Target { get; set; }
    }
}
