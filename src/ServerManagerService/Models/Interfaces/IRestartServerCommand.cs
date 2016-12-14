using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerManagerService.Models.Interfaces
{
    public interface IRestartServerCommand : IMessage
    {
        string Name { get; }
    }
}
