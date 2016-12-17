using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceContracts.Interfaces
{
    public enum CommandType
    {
        StartServer,
        StopServer,
        RestartServer,
        AddServer,
        DeleteServer,
        EditServer,
        NumCommandTypes
    }

    public interface ICommand
    {
        CommandType Type { get; }
    }
}
