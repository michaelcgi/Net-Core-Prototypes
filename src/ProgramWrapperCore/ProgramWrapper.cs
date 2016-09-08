using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json;
using System.Runtime.InteropServices;

namespace ProgramWrapperCore
{
    public class ProgramWrapper
    {
        public ProgramWrapper()
        {
        }

        public async Task<ExecutionResult> Execute(ExecutionRequest request)
        {
            string output = null;
            DateTime? runTime = null;
            TimeSpan? runDuration = null;
            Exception exception = null;

            try
            {
                runTime = DateTime.Now;
                output = await ExecuteProcess(request.FileName, request.Arguments);
                runDuration = DateTime.Now.Subtract(runTime.Value);
            }
            catch (Exception ex)
            {
                // TODO: Logging
                exception = ex;
            }

            return CreateExecutionResult(output, runTime, runDuration, exception);
        }

        private ExecutionResult CreateExecutionResult(
            string output, DateTime? runTime, TimeSpan? runDuration, Exception exception)
        {
            return new ExecutionResult()
            {
                Output = output,
                RunTime = runTime,
                RunDuration = runDuration,
                Exception = exception,
                OSDescription = RuntimeInformation.OSDescription
           };
        }

        private Task<string> ExecuteProcess(string fileName, string arguments)
        {
            var tcs = new TaskCompletionSource<string>();

            var process = new Process()
            {
                StartInfo =
                {
                    FileName = fileName,
                    Arguments = arguments,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                },
                EnableRaisingEvents = true
            };

            StringBuilder outputBuffer = new StringBuilder();
            process.OutputDataReceived += (sender, args) => outputBuffer.AppendLine(args.Data);
            // process.ErrorDataReceived += (sender, args) => errorBuffer.Append(args.Data);

            process.Exited += (sender, args) =>
            {
                tcs.SetResult(outputBuffer.ToString());
                process.Dispose();
            };

            process.Start();
            process.BeginOutputReadLine();
            // process.BeginErrorReadLine();

            return tcs.Task;
        }
    }
}
