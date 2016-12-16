using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using ServerManagerService.Models.Interfaces;

namespace ServerManagerService.Models
{
    public enum MessageType
    {
        Command,
        Query,
        NumMessageTypes
    }

    public interface IMessage<TPayload>
    {
        string Id { get; }
        MessageType Type { get; }
        TPayload Payload { get; }
    }
}
