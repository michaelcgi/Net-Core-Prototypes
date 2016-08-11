using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace StartProcessCore
{
    public class Program
    {
        public static void Main(string[] args)
        {

            if (args.Length == 0 || args.Length > 2)
            {
                Console.Out.WriteLine("StartProcessCore [fileName] <arguments>");
                return;
            }

            var psi = CreateProcessStartInfo(args);
            var p = Process.Start(psi);

            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();

            Console.Out.WriteLine("OUTPUT:");
            Console.Out.WriteLine(output);
        }

        private static ProcessStartInfo CreateProcessStartInfo(string[] args)
        {
            var psi = new ProcessStartInfo();
            psi.FileName = args[0];
            if (args.Length > 1)
            {
                psi.Arguments = args[1];
            }

            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;

            return psi;
        }
    }
}
