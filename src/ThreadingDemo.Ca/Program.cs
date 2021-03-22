using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace RunTasksInParallel
{
    class Program
    {
        private static async Task Main(string[] args)
        {
            var directoryService = new DirectoryService();
            var createFileService = new CreateFileService();
            var millisecondsTimeout = 2000;
            var taskCount = 10;

            directoryService.CreateDirectory();
            directoryService.ClearDirectory();
            //createFileService.Handle();

            var tasks = new List<Task<string>>();

            var stopWatch = new Stopwatch();
            stopWatch.Start();
            Console.WriteLine("... Start");
            Console.WriteLine();

            for (int i = 0; i < taskCount; i++)
            {
                tasks.Add(createFileService.HandleAsync(millisecondsTimeout));
            }

            await Task.WhenAll(tasks);

            stopWatch.Stop();
            var timeSpan = stopWatch.Elapsed;

            var elapsedTime = $"{timeSpan.Hours}:{timeSpan.Minutes}:{timeSpan.Seconds}.{timeSpan.Milliseconds}";
            var allthreadsTotalTime = $"0:0:{millisecondsTimeout * taskCount / 1000}.000";

            Console.WriteLine();
            Console.WriteLine("allthreadsTotalTime {0}", allthreadsTotalTime);
            Console.WriteLine("elapsedTime {0}", elapsedTime);

            Console.WriteLine();
            Console.WriteLine("... End");
            Console.ReadLine();
        }
    }
}
