using System;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using ExecutionCore.Model;
using System.Threading;

namespace ExecutionCore
{
    public class ProgramWrapper
    {
        public ProgramWrapper()
        {
        }

        public async Task<ExecutionResult> ExecuteAsync(ExecutionRequest request)
        {
            string standardOutput = null;
            DateTime? runTime = null;
            TimeSpan? runDuration = null;
            Exception exception = null;

            try
            {
                runTime = DateTime.Now;
                standardOutput = await ExecuteProcess(request.FileName, request.Arguments);
                runDuration = DateTime.Now.Subtract(runTime.Value);
            }
            catch (Exception ex)
            {
                // TODO: Logging
                exception = ex;
            }

            return CreateExecutionResult(request, standardOutput, null, runTime, runDuration, exception);
        }

        private ExecutionResult CreateExecutionResult(
            ExecutionRequest request, string standardOutput, string errorOutput, DateTime? runTime, TimeSpan? runDuration, Exception exception)
        {
            return new ExecutionResult()
            {
                Request = request,
                StandardOutput = standardOutput,
                ErrorOutput = errorOutput,
                RunTime = runTime,
                RunDuration = runDuration,
                ExceptionXml = exception == null ? "" : ExceptionUtils.GetXmlString(exception),
                IPAdress = null,
                OsDescription = RuntimeInformation.OSDescription,
                ThreadId = Thread.CurrentThread.ManagedThreadId
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
