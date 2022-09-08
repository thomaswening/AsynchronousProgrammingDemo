
// MS .NET documentation - Asynchronous programming with async and await: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/
// Tim Corey - C# Async / Await - Make your app more responsive and faster with asynchronous programming: https://www.youtube.com/watch?v=2moh18sh5p4
// Asynchronous Programming with Async and Await in ASP.NET Core: https://code-maze.com/asynchronous-programming-with-async-and-await-in-asp-net-core/
// Using Task.Run in Conjunction with Async/Await: https://www.pluralsight.com/guides/using-task-run-async-await
// C# async, await Examples: https://www.dotnetperls.com/async
// How Do I Debug Async Code in Visual Studio? https://devblogs.microsoft.com/visualstudio/how-do-i-debug-async-code-in-visual-studio/

namespace AsynchronousProgrammingDemo
{
    internal class Program
    {
        #region Methods

        // Main must be async because it will run asynchronous methods and await their execution
        // It must return Task since synchronously, it would return void: static void Main => static ASYNC TASK Main
        // async void should only be used for events !
        static async Task Main(string[] args)
        {

            MakeJoke();
            Console.ReadKey();
            Console.Clear();

            await EasyExample.RunExampleAsync();
            Console.WriteLine();
            Console.ReadKey();
            Console.Clear();

            await ExampleWithReturnTypes.RunExampleAsync();
            Console.WriteLine();
            Console.ReadKey();
            Console.Clear();

            await ExampleTaskRun.RunExampleAsync();
            Console.WriteLine();
            Console.ReadKey();
            Console.Clear();

            await TaskInformationExample.RunExampleAsync();
            Console.WriteLine();
            Console.ReadKey();
            Console.Clear();

            SynchronousBreakfast syncBreakfast = new(
                butterToasts: 3,
                boiledEggs: 2,
                cupsOfCoffee: 2,
                fastForwardCoeff: 10);
            Console.WriteLine();
            Console.ReadKey();

            AsynchronousBreakfast asyncBreakfast = new(
                butterToasts: 3,
                boiledEggs: 2,
                cupsOfCoffee: 2,
                fastForwardCoeff: 10);
            Console.ReadKey();

        }

        static void MakeJoke()
        {
            Console.WriteLine("But the question is");
            Thread.Sleep(1000);

            Task answerTask = Answer();

            Console.WriteLine("if we couldn't also");
            Thread.Sleep(1000);
           
            Console.WriteLine("do this asynchronously");

            answerTask.Wait();
        }

        static async Task Answer()
        {
            Console.WriteLine("\t Of course");
            await Task.Delay(2000);

            Console.WriteLine("\t we can!");
        }

        #endregion Methods
    }
}