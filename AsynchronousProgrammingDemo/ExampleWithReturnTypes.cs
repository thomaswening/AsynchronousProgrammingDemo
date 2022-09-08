using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsynchronousProgrammingDemo
{
    internal static class ExampleWithReturnTypes
    {
        #region Methods

        public static async Task RunExampleAsync() 
        {
            Console.WriteLine("Starting ExampleWithReturnTypes");
            Task<int> sumToNAsyncTask = SumToNAsync(5);

            ShortProcess();

            // We wait for sumToNAsyncTask to finish and save the returned value (type int) into result
            int result = await sumToNAsyncTask;
            Console.WriteLine($"SumToNAsync returned >> {result}");
        }

        // SumToNAsync returns an int (sum) and thus its return typ is Task<int>
        static async Task<int> SumToNAsync(int n)
        {
            int sum = 0;
            
            Console.WriteLine("SumToNAsync Started");

            for (int i = 1; i <= n; i++)
            {
                // Task.Delay() is asynchronous itself
                await Task.Delay(1000); // await: execution halted until Task is finished 

                Console.WriteLine($"Long process: {i}/{n}");
                sum += i;
            }

            Console.WriteLine("SumToNAsync Completed");

            return sum;
        }

        static void ShortProcess()
        {
            Console.WriteLine("\tShort process Started");

            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Short process: bla");
            }

            Console.WriteLine("\tShort process Completed");
        }

        #endregion Methods
    }
}
