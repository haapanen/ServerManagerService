using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServerManagerService.Models.Interfaces;

namespace ServerManagerService.Models
{
    public class StopServerCommand : IStopServerCommand
    {
        public StopServerCommand(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
