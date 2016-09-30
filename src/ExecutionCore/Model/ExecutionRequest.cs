using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExecutionCore.Model
{
    public class ExecutionRequest
    {
        private static int _nextIndex = 0;

        public int Id { get; set; }
        public string FileName { get; set; }
        public string Arguments { get; set; }
        public int? ExecutionCount { get; set; }

        public int Index { get; set; }

        public ExecutionRequest()
        {
            Index = _nextIndex;
            _nextIndex += 1;

            ExecutionCount = 1;
        }
    }
}