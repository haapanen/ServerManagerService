using ServiceContracts.Interfaces;

namespace ServiceContracts
{
    public class RestartServerCommand : IRestartServerCommand
    {
        public RestartServerCommand(string name)
        {
            Type = CommandType.RestartServer;
            Name = name;
        }

        public CommandType Type { get; }
        public string Name { get; }
    }
}
