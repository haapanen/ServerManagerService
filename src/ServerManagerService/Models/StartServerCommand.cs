using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServerManagerService.Models.Interfaces;

namespace ServerManagerService.Models
{
    public class StartServerCommand : IStartServerCommand
    {
        public StartServerCommand(string payload, string name)
        {
            Id = Guid.NewGuid().ToString("B");
            Type = MessageType.Command;
            Payload = payload;
            Name = name;
        }

        public string Id { get; }
        public MessageType Type { get; }
        public string Payload { get; }
        public string Name { get; }
    }
}
