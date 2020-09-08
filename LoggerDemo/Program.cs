using Microsoft.Extensions.Logging;
using System;
using System.Threading;

namespace LoggerDemo
{
    /**
     * 1) Install Microsoft.Extension.Logging
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            LogExample logExample = new LogExample();
            //logExample.LogToAll();
            logExample.LogWithConfig();

            Thread.Sleep(100);
        }

    }
}
