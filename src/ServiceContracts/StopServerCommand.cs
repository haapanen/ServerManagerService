using ServiceContracts.Interfaces;

namespace ServiceContracts
{
    public class StopServerCommand : IStopServerCommand
    {
        public StopServerCommand(string name)
        {
            Type = CommandType.StopServer;
            Name = name;
        }

        public CommandType Type { get; }
        public string Name { get; }
    }
}
