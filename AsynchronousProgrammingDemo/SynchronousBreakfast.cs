using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsynchronousProgrammingDemo
{
    internal class SynchronousBreakfast
    {
        #region Fields

        int boiledEggs;
        int butterToasts;
        int cupsOfCoffee;
        double fastForwardCoeff;

        #endregion Fields

        #region Constructors

        public SynchronousBreakfast(int butterToasts, int boiledEggs, int cupsOfCoffee, double fastForwardCoeff=1.0)
        {
            this.butterToasts = butterToasts;
            this.boiledEggs = boiledEggs;
            this.cupsOfCoffee = cupsOfCoffee;
            this.fastForwardCoeff = fastForwardCoeff;

            MakeBreakfast();
        }

        #endregion Constructors

        #region Methods

        void BoilEggs()
        {
            Console.WriteLine($"Boiling {boiledEggs} eggs...");

            for (int i = 0; i < boiledEggs; i++)
            {
                BoilOneEgg();
            }
            Console.WriteLine($"{boiledEggs} boiled eggs are ready!");
        }

        void BoilOneEgg()
        {
            Console.WriteLine("Boiling an egg...");
            Time.Wait(20, fastForwardCoeff);
            Console.WriteLine("Egg done.");
        }

        void MakeBreakfast()
        {
            double elapsedTime;
            Stopwatch stopwatch = Stopwatch.StartNew();
            Console.WriteLine(">>> Preparing a synchronous breakfast...");

            MakeButterToast();
            BoilEggs();
            MakeCoffee();

            Console.WriteLine("Synchronous breakfast is served!");
            elapsedTime = fastForwardCoeff * stopwatch.ElapsedMilliseconds / 1000.0;
            Console.WriteLine($"\nTime elapsed >>> {Time.ToString(elapsedTime)}\n\n");
        }

        void MakeButterToast()
        {
            Console.WriteLine($"Making {butterToasts} butter toasts...");

            for (int i = 0; i < butterToasts; i++)
            {
                ToastOneBread();
                SmearButterOnToast();
            }
            Console.WriteLine($"{butterToasts} butter toasts are ready!");
        }

        void MakeCoffee()
        {
            Console.WriteLine($"Making {cupsOfCoffee} cups of coffee...");

            for (int i = 0; i < cupsOfCoffee; i++)
            {
                MakeCupOfCoffee();
            }
            Console.WriteLine($"{cupsOfCoffee} cups of coffee are ready!");
        }

        void MakeCupOfCoffee()
        {
            Console.WriteLine("Waiting for the coffee machine...");
            Time.Wait(60, fastForwardCoeff);
            Console.WriteLine("One cup of coffee ready!");
        }

        void SmearButterOnToast()
        {
            Console.WriteLine("Smearing butter on toast...");
            Time.Wait(3, fastForwardCoeff);
            Console.WriteLine("One butter toast ready!");
        }

        void ToastOneBread()
        {
            Console.WriteLine("Toasting a bread...");
            Time.Wait(30, fastForwardCoeff);
            Console.WriteLine("Toast bread done.");
        }

        #endregion Methods
    }
}
