using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using HelloDatabaseCore.SQLServer;
using HelloDatabaseCore.Model;

namespace HelloDatabaseCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var db = new DatabaseContext())
            {
                var request = new ExecutionRequest() { FileName = "ping", Arguments = "chalmers.se" };
                db.ExecutionRequests.Add(request);

                var results = new List<ExecutionResult>();

                for (int i = 0; i < 5; i++)
                {
                    db.ExecutionResults.Add(
                        new ExecutionResult()
                        {
                            ExecutionRequest = request,
                            RunTime = DateTime.Now,
                            RunDuration = TimeSpan.FromSeconds(i),
                            Output = string.Format("Output {0}", i + 1)
                        });
                }

                var count = db.SaveChanges();
                Console.WriteLine("{0} records saved to database", count);
            }
        }
    }
}
