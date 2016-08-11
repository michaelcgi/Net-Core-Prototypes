using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Out.WriteLine("Hello world! Time is: " +
                DateTime.Now.ToString("t"));
        }
    }
}
