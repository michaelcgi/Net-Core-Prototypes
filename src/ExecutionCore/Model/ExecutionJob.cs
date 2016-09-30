using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExecutionCore.Model
{
    public class ExecutionJob
    {
        public ExecutionJob()
        {
            Requests = new List<ExecutionRequest>();
            Results = new List<ExecutionResult>();

            Status = ExecutionStatus.New;
        }

        public int Id { get; set; }
        public ExecutionStatus Status { get; set; }

        public ExecutionRequest Request
        {
            get
            {
                if (!IsInSingleRequestMode())
                {
                    return null;
                }
                else
                {
                    return Requests.FirstOrDefault();
                }
            }

            set
            {
                if (!IsInSingleRequestMode())
                {
                    throw new NotSupportedException("ExecutionJob not in single request mode.");
                }

                Requests = new ExecutionRequest[] { value }.ToList();
            }
        }

        public ICollection<ExecutionRequest> Requests { get; set; }

        public IEnumerable<ExecutionRequest> RequestLeafs
        {
            get
            {
                foreach (var request in Requests)
                {
                    var executionCount = request.ExecutionCount ?? 1;
                    for (int i = 0; i < executionCount; i++)
                    {
                        yield return new ExecutionRequest()
                        {
                            FileName = request.FileName, Arguments = request.Arguments
                        };
                    }
                }
            }
        }

        public ICollection<ExecutionResult> Results { get; set; }

        private bool IsInSingleRequestMode()
        {
            return Requests.Count <= 1;
        }
    }
}
