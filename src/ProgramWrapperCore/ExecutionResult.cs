using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgramWrapperCore
{
    public class ExecutionResult
    {
        public DateTime? RunTime { get; set; }
        public TimeSpan? RunDuration { get; set; }
        public string Output { get; set; }
        public Exception Exception { get; set; }
        public string OSDescription { get; set; }
    }
}
