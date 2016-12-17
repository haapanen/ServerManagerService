namespace ServiceContracts.Interfaces
{
    public interface IStartServerCommand : ICommand
    {
        string Name { get; }
    }
}
