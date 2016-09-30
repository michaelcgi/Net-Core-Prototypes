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

        public ExecutionJobQueue()
        {
        }

        public void ExecuteQueuedJobs()
        {
            using (var repository = new DbExecutionRepository())
            {
                var queuedJobs = repository.FindByStatus(ExecutionStatus.Queued);

                foreach (var executionJob in queuedJobs)
                {
                    WriteStartingLine(executionJob);

                    executionJob.Status = ExecutionStatus.Running;
                    repository.Update(executionJob);

                    var tasks = new List<Task<ExecutionResult>>();
                    foreach (var request in executionJob.RequestLeafs)
                    {
                        var task = ExecuteRequestAsync(request, executionJob);
                        tasks.Add(task);
                    }

                    // Wait for all execution requests to finish
                    Task.WaitAll(tasks.ToArray());

                    executionJob.Status = ExecutionStatus.Finished;
                    repository.Update(executionJob);

                    WriteFinishedLine(executionJob);
                }
            }
        }

        private Task<ExecutionResult> ExecuteRequestAsync(ExecutionRequest request, ExecutionJob job)
        {
                var task = ExecuteRequestAsync(request);
                var continuationTask = task.ContinueWith((antecendent) =>
                {
                    using (var repository = new DbExecutionRepository())
                    {
                        job.Results.Add(task.Result);
                        repository.Update(job);

                        return antecendent.Result;
                    }
                });
                return continuationTask;
        }

        private Task<ExecutionResult> ExecuteRequestAsync(ExecutionRequest request)
        {
            WriteStartingLine(request);

            var programWrapper = new ProgramWrapper();
            var task = programWrapper.ExecuteAsync(request);
            var continuationTask = task.ContinueWith((antecendent) => 
            {
                WriteFinishedLine(request);
                return antecendent.Result;
            });
            
            return continuationTask;
        }

        private static void WriteStartingLine(ExecutionRequest request)
        {
            Console.WriteLine("Starting (R-{0}): {1} {2}", request.Index, request.FileName, request.Arguments);
        }

        private static void WriteFinishedLine(ExecutionRequest request)
        {
            Console.WriteLine("Finished (R-{0}): {1} {2}", request.Index, request.FileName, request.Arguments);
        }

        private static void WriteStartingLine(ExecutionJob job)
        {
            Console.WriteLine("Starting (J-{0})", job.Id);
        }

        private static void WriteFinishedLine(ExecutionJob job)
        {
            Console.WriteLine("Finished (J-{0})", job.Id);
        }
    }
}
