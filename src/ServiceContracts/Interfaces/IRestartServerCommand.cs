namespace ServiceContracts.Interfaces
{
    public interface IRestartServerCommand : ICommand
    {
        string Name { get; }
    }
}
