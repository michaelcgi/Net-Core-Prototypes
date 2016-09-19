using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloDatabaseCore.Model
{
    public enum ExecutionStatus
    {
        New = 0,
        Queued = 1,
        Running = 2,
        Finished = 3
    }
}
