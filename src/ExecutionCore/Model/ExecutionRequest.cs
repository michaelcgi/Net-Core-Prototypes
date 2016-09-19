using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExecutionCore.Model
{
    public class ExecutionRequest
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string Arguments { get; set; }
    }
}