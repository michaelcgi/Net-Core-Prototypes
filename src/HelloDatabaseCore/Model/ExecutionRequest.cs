using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloDatabaseCore.Model
{
    public class ExecutionRequest
    {
        public int ExecutionRequestId { get; set; }
        public string FileName { get; set; }
        public string Arguments { get; set; }
        public DateTime? Time { get; set; }

        public ExecutionRequest()
        {
            Time = DateTime.Now;
        }
    }
}
