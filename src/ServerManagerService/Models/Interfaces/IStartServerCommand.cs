﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerManagerService.Models.Interfaces
{
    public interface IStartServerCommand : IMessage
    {
        string Name { get; }
    }
}
