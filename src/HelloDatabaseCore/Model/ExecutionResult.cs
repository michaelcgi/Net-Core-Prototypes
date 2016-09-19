using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloDatabaseCore.Model
{
    public class ExecutionResult
    {
        public int ExecutionResultId { get; set; }
        public ExecutionRequest ExecutionRequest { get; set; }
        public DateTime? RunTime { get; set; }
        public TimeSpan? RunDuration { get; set; }
        public string Output { get; set; }
        public string ExceptionXml { get; set; }
        public string OSDescription { get; set; }
    }
}
