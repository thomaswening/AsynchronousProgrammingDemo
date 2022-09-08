using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsynchronousProgrammingDemo
{
    static internal class Time
    {
        #region Fields

        static int dayInSeconds = 24 * hourInSeconds;
        static int hourInSeconds = 60 * minuteInSeconds;
        static int minuteInSeconds = 60;
        static int yearInSeconds = 365 * dayInSeconds;

        #endregion Fields

        #region Methods

        public static string ToString(double timeInSeconds)
        {
            int years;
            int days;
            int hours;
            int minutes;
            double remainderInSeconds;

            years = (int)Math.Floor(timeInSeconds / yearInSeconds);
            remainderInSeconds = timeInSeconds % yearInSeconds;

            days = (int)Math.Floor(remainderInSeconds / dayInSeconds);
            remainderInSeconds = remainderInSeconds % dayInSeconds;

            hours = (int)Math.Floor(remainderInSeconds / hourInSeconds);
            remainderInSeconds = remainderInSeconds % hourInSeconds;

            minutes = (int)Math.Floor(remainderInSeconds / minuteInSeconds);
            remainderInSeconds = remainderInSeconds % minuteInSeconds;

            StringBuilder sb = new();

            if (years > 0) sb.Append($"{years} yr ");
            if (days > 0) sb.Append($"{days} d ");
            if (hours > 0) sb.Append($"{hours} h ");
            if (minutes > 0) sb.Append($"{minutes} min ");
            if (remainderInSeconds > 0) sb.Append(remainderInSeconds.ToString("0.00") + " s");

            return sb.Length != 0 ? sb.ToString() : "0.00 s";
        }

        public static void Wait(int seconds, double fastForwardCoeff=1.0)
        {
            int milliseconds = (int)Math.Round(1000 * seconds / fastForwardCoeff);
            Thread.Sleep(milliseconds);
        }

        #endregion Methods
    }
}
