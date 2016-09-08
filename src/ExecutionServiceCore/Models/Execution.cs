using ProgramWrapperCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExecutionServiceCore.Models
{

    public enum ExecutionStatus
    {
        New = 0,
        Queued = 1,
        Running = 2,
        Finished = 3
    }

    public class ExecutionJob
    {
        public int Id { get; set; }
        public ExecutionStatus Status { get; set; }

        public ExecutionRequest Request { get; set; }

        public ExecutionResult Result { get; set; }

        public ExecutionJob()
        {
            Status = ExecutionStatus.New;
        }
    }
}
