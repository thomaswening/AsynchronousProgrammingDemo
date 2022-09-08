using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsynchronousProgrammingDemo
{
    internal class AsynchronousBreakfast
    {
        #region Fields

        int boiledEggs;
        int butterToasts;
        int cupsOfCoffee;
        double fastForwardCoeff;

        #endregion Fields

        #region Constructors

        public AsynchronousBreakfast(int butterToasts, int boiledEggs, int cupsOfCoffee, double fastForwardCoeff=1.0)
        {
            this.butterToasts = butterToasts;
            this.boiledEggs = boiledEggs;
            this.cupsOfCoffee = cupsOfCoffee;
            this.fastForwardCoeff = fastForwardCoeff;

            MakeBreakfastAsync().Wait();
        }

        #endregion Constructors

        #region Methods

        async Task BoilEggsAsync()
        {
            Console.WriteLine($"Boiling {boiledEggs} eggs...");

            // Instead of boiling them one after the other, we add all the egg boiling tasks into a list of Tasks...
            List<Task> eggsTasks = new();

            for (int i = 0; i < boiledEggs; i++)
            {
                eggsTasks.Add(BoilOneEggAsync()); // add another egg to the boiling water... and another... etc
            }

            // And then wait until they are all done boiling.
            await Task.WhenAll(eggsTasks);
            Console.WriteLine($"{boiledEggs} boiled eggs are ready!");
        }

        async Task BoilOneEggAsync()
        {
            Console.WriteLine("Boiling an egg...");
            await Time.WaitAsync(20, fastForwardCoeff);
            Console.WriteLine("Egg done.");
        }

        async Task MakeBreakfastAsync()
        {
            double elapsedTime;
            Stopwatch stopwatch = Stopwatch.StartNew();
            Console.WriteLine(">>> Preparing an asynchronous breakfast...");

            Task butterToastTask = MakeButterToastAsync();
            Task eggsTask = BoilEggsAsync();
            Task coffeeTask = MakeCoffeeAsync();

            await Task.WhenAll(butterToastTask, eggsTask, coffeeTask); // wait until ALL of them are finished

            Console.WriteLine("Synchronous breakfast is served!");
            elapsedTime = fastForwardCoeff * stopwatch.ElapsedMilliseconds / 1000.0;
            Console.WriteLine($"\nTime elapsed >>> {Time.ToString(elapsedTime)}\n\n");
        }

        async Task MakeButterToastAsync()
        {
            Console.WriteLine($"Making {butterToasts} butter toasts...");

            // We have several toasters, so we just stuff all of the toasting tasks in the toasters
            List<Task> butterToastTasks = new();

            for (int i = 0; i < butterToasts; i++)
            {
                butterToastTasks.Add(ToastOneBreadAsync());
                butterToastTasks.Add(SmearButterOnToastAsync()); // the toasters can even smear the toasts while they are toasting (not very realistic, i know)
            }

            // and again wait until all the toasts are done tosted and smeared
            await Task.WhenAll(butterToastTasks);
            Console.WriteLine($"{butterToasts} butter toasts are ready!");
        }

        async Task MakeCoffeeAsync()
        {
            Console.WriteLine($"Making {cupsOfCoffee} cups of coffee...");

            // ... just jam them cups in there and turn the thing on - we can fill several cups simultaneously
            List<Task> coffeeTasks = new();

            for (int i = 0; i < cupsOfCoffee; i++)
            {
                coffeeTasks.Add(MakeCupOfCoffeeAsync());
            }

            await Task.WhenAll(coffeeTasks);
            Console.WriteLine($"{cupsOfCoffee} cups of coffee are ready!");
        }

        async Task MakeCupOfCoffeeAsync()
        {
            Console.WriteLine("Time.Waiting for the coffee machine...");
            await Time.WaitAsync(60, fastForwardCoeff);
            Console.WriteLine("One cup of coffee ready!");
        }

        async Task SmearButterOnToastAsync()
        {
            Console.WriteLine("Smearing butter on toast...");
            await Time.WaitAsync(3, fastForwardCoeff);
            Console.WriteLine("One butter toast ready!");
        }

        async Task ToastOneBreadAsync()
        {
            Console.WriteLine("Toasting a bread...");
            await Time.WaitAsync(30, fastForwardCoeff);
            Console.WriteLine("Toast bread done.");
        }

        #endregion Methods
    }
}
