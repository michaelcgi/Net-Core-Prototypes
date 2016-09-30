using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExecutionCore.Model
{
    // TODO: Add request

    public class ExecutionResult
    {
        public int Id { get; set; }
        public ExecutionRequest Request { get; set; }
        public DateTime? RunTime { get; set; }
        public TimeSpan? RunDuration { get; set; }
        public string StandardOutput { get; set; }
        public string ErrorOutput { get; set; }
        public string ExceptionXml { get; set; }
        public string IPAdress { get; set; }
        public string OsDescription { get; set; }
        public int ThreadId { get; set; }
    }
}
