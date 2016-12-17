namespace ServiceContracts.Interfaces
{
    public interface IStopServerCommand : ICommand
    {
        string Name { get; }
    }
}
