namespace ServiceContracts.Interfaces
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
