using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ExecutionControllerCore.Model;
using ExecutionCore;
using ExecutionCore.Model;

namespace ExecutionControllerCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Starting ExecutionController");

            // Loop forever
            while (true)
            {
                try
                {
                    var queueCount = ExecutionJobQueue.GetCount();

                    // Check any requests queue
                    if (queueCount > 0)
                    {
                        Console.WriteLine("Executing Queued Jobs: {0} jobs", queueCount);

                        // Handle request queue
                        var queue = new ExecutionJobQueue();
                        queue.ExecuteQueuedJobs();
                    }
                    
                    // Sleep
                    Thread.Sleep(1000);
                }
                catch (ExecutionControllerException ex)
                {
                    // Logg exception

                }
            }
        }
    }
}
