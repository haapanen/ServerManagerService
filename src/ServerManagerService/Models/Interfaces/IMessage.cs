using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace ServerManagerService.Models
{
    public enum MessageType
    {
        Command,
        Query,
        NumMessageTypes
    }

    public interface IMessage
    {
        string Id { get; }
        MessageType Type { get; }
        string Payload { get; }
    }
}
