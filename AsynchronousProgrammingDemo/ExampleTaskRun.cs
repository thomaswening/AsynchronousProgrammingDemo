using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsynchronousProgrammingDemo
{
    internal static class ExampleTaskRun
    {
        public static async Task RunExampleAsync()
        {
            Console.WriteLine("Starting RunExampleAsync");

            // We can also run synchronous methods asynchronously by running them as a Task
            // Just pass the method identifier as an argument to Task.Run()

            Task actionTask = Task.Run(SynchronousAction); 
            Task<int> functionTask = Task.Run(SynchronousFunction);

            // Turn the method into a lambda, if you must pass arguments
            Task<int> functionWithParamsTask = Task.Run(() => SynchronousFunctionWithParams(5));

            await actionTask;
            int resultFunctionTask = await functionTask;
            Console.WriteLine($"Result SynchronousFunction: {resultFunctionTask}");

            int resultFunctionWithParamsTask = await functionWithParamsTask;
            Console.WriteLine($"Result SynchronousFunction: {resultFunctionWithParamsTask}");
        }

        static void SynchronousAction()
        {
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine("I am an action");
            }
        }

        static int SynchronousFunction()
        {
            int sum = 0;

            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(1000);
                sum += i;
                Console.WriteLine($"SynchronousFunction: {sum}");
            }

            return sum;
        }

        static int SynchronousFunctionWithParams(int start)
        {
            int sum = start;

            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(1000);
                sum += i;
                Console.WriteLine($"SynchronousFunctionWithParams: {sum}");
            }

            return sum;
        }
    }
}
