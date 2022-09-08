using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsynchronousProgrammingDemo
{
    internal static class EasyExample
    {
        #region Methods

        // RunExampleAsync must be async because we want to execute asynchronous methods in it
        // and we want to await their execution - no async => no await
        // The return type must be Task because synchronously, it would return void
        public static async Task RunExampleAsync() // async methods should have the suffix "Async"
        {
            Console.WriteLine("Starting EasyExample");

            // We start an asynchronous method - it returns a Task
            Task longProcessTask = LongProcessAsync();

            // We start a synchronous method, meanwhile LongProcessAsync is still being executed
            // in the Task longProcessTask
            ShortProcess();

            // In the end, we wait for longProcessTask to finish
            await longProcessTask;
        }

        static async Task LongProcessAsync()
        {
            // While the main thread continues on by executing ShortProcess,
            // LongProcessAsync is being executed as the Task longProcessTask on another thread
            
            Console.WriteLine("Long process Started");

            for (int i = 0; i < 4; i++)
            {
                // Task.Delay() is asynchronous itself
                await Task.Delay(1000); // await: execution halted until Task is finished 

                Console.WriteLine($"Long process: {i + 1}/4");
            }

            Console.WriteLine("Long process Completed");

            // The Task is Completed: return to the main thread
        }

        static void ShortProcess()
        {
            Console.WriteLine("\tShort process Started");

            Thread.Sleep(1000);

            Console.WriteLine("\tShort process Completed");
        }

        #endregion Methods
    }
}
