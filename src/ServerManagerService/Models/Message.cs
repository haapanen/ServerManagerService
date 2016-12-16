using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerManagerService.Models
{
    public class Message<TPayload> : IMessage<TPayload>
    {
        public Message(MessageType type, TPayload payload)
        {
            Id = Guid.NewGuid().ToString("B");
            Type = type;
            Payload = payload;
        }

        public string Id { get; }
        public MessageType Type { get; }
        public TPayload Payload { get; }
    }
}
