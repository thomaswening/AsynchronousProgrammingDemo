using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsynchronousProgrammingDemo
{
    internal static class TaskInformationExample
    {
        public static async Task RunExampleAsync()
        {
            Console.WriteLine("Starting TaskExample");

            Task task = Task.Run(DoSomething);

            Console.WriteLine(GetTaskInfoString(task));
            Console.WriteLine();

            await task;
            Console.WriteLine(GetTaskInfoString(task));
        }

        static async Task DoSomething()
        {
            Console.WriteLine("Starting Task...");
            for (int i = 0; i < 5; i++)
            {
                await Task.Delay(1000);
            }

            Console.WriteLine("Ending Task...");

        }

        static string GetTaskInfoString(Task task)
        {
            StringBuilder sb = new();
            sb.AppendLine("Id: " + task.Id);
            sb.AppendLine("Status: " + task.Status);
            sb.AppendLine("IsCanceled: " + task.IsCanceled);
            sb.AppendLine("IsCompleted: " + task.IsCompleted);
            sb.AppendLine("IsCompletedSuccessfully: " + task.IsCompletedSuccessfully);
            sb.AppendLine("IsFaulted: " + task.IsFaulted);

            return sb.ToString();
        }
    }
}
