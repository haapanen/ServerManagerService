using ServiceContracts.Interfaces;

namespace ServiceContracts
{
    public class StartServerCommand : IStartServerCommand
    {
        public StartServerCommand(string name)
        {
            Type = CommandType.StartServer;
            Name = name;
        }

        public CommandType Type { get; }
        public string Name { get; }
    }
}
