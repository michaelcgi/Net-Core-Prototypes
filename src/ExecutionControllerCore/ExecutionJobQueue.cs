using ExecutionCore;
using ExecutionCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExecutionControllerCore.Model
{
    public class ExecutionJobQueue
    {
        public static int GetCount()
        {
            var db = new DatabaseContext();
            var query = from ej in db.ExecutionJobs where ej.Status == ExecutionStatus.Queued select ej;
            return query.Count();
        }

        private List<ExecutionJob> _executionJobs;

        public ExecutionJobQueue()
        {
        }

        public void ExecuteQueuedJobs()
        {
            var repository = new DbExecutionRepository();
            var queuedJobs = repository.FindByStatus(ExecutionStatus.Queued);

            foreach (var executionJob in queuedJobs)
            {
                executionJob.Status = ExecutionStatus.Running;
                repository.Update(executionJob);

                foreach (var request in executionJob.Requests)
                {
                    var result = ExecuteRequest(request);
                    executionJob.Results.Add(result);
                    repository.Update(executionJob);
                }

                executionJob.Status = ExecutionStatus.Finished;
                repository.Update(executionJob);
            }
        }

        private ExecutionResult ExecuteRequest(ExecutionRequest request)
        {
            Console.WriteLine("Starting ({0}): {1} {2}", request.Id, request.FileName, request.Arguments);

            var programWrapper = new ProgramWrapper();
            var task = programWrapper.Execute(request);
            task.Wait();

            Console.WriteLine("Finished ({0}): {1} {2}", request.Id, request.FileName, request.Arguments);
            return task.Result;
        }
    }
}
