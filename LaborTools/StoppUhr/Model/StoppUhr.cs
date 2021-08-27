using System;
using System.Threading;

namespace StoppUhr.Model
{
    public class StoppUhr
    {

        public enum Modusstoppuhr
        {
            Stop = 0,
            CountDown = 1,
            Aktiv = 2
        }

        public Modusstoppuhr ModusStoppUhr;
        public int CountDownZaehler;
        public int ZyklusZeit;
        public DateTime Startzeit = new();

        public StoppUhr()
        {


            System.Threading.Tasks.Task.Run(StoppUhrTask);
        }
        private void StoppUhrTask()
        {
            while (true)
            {

                switch (ModusStoppUhr)
                {
                    case Modusstoppuhr.CountDown: break;
                    case Modusstoppuhr.Stop: break;
                    case Modusstoppuhr.Aktiv: break;
                    default: throw new ArgumentOutOfRangeException();
                }


                Thread.Sleep(10);
            }
            // ReSharper disable once FunctionNeverReturns
        }
    }
}