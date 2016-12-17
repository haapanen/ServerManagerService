using System;
using ServiceContracts.Interfaces;

namespace ServiceContracts
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
