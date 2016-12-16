using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServerManagerService.Models.Interfaces;

namespace ServerManagerService.Models
{
    public class RestartServerCommand : IRestartServerCommand
    {
        public RestartServerCommand(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
